using IdleActionFarm.Physics;
using System.Collections.Generic;
using IdleActionFarm.Ui;
using UnityEngine;
using Zenject;

namespace IdleActionFarm.GameplayObjects
{
    public class Porter : MonoBehaviour
    {
        [SerializeField] private Transform _initialPosition;
        [SerializeField] private Transform _container;

        private List<IBlock> _blocks = new List<IBlock>();
        private ICollector _collector;
        private BlockDistributor _distributor;
        private UiPlayerStatus _uiPlayerStatus;

        [Inject]
        private void Constructor(ICollector collector, BlockDistributor distributor, UiPlayerStatus playerStatus) => 
            (_collector, _distributor, _uiPlayerStatus) = (collector, distributor, playerStatus);

        private void OnEnable() => _collector.OnAccumulated += Add;

        private void OnDisable() => _collector.OnAccumulated -= Add;

        public IEnumerable<IBlock> TakeOffBlocks()
        {
            _blocks.Reverse();
            IEnumerable<IBlock> blocks = _blocks;

            _blocks = new List<IBlock>();
            _collector.Clear();
            
            _uiPlayerStatus.SetNumberOfBlockInStack(0);
            
            return blocks;
        }
        
        private void Add(IBlock block)
        {
            block.Self.SetParent(_container);
            UpdateTransform(block.Self);
            Vector3 offset = new Vector3(0, block.Self.localScale.y, 0) * _blocks.Count;
            _distributor.MoveForward(block.Self, _initialPosition, offset);
            _blocks.Add(block);
            
            _uiPlayerStatus.SetNumberOfBlockInStack(_blocks.Count);
        }

        private void UpdateTransform(Transform block) =>  block.rotation = Quaternion.identity;
    }
}