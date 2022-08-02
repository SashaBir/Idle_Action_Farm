using IdleActionFarm.Physics;
using System.Collections.Generic;
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
        private PlayerStatus _playerStatus;

        [Inject]
        private void Constructor(ICollector collector, BlockDistributor distributor, PlayerStatus playerStatus) => 
            (_collector, _distributor, this._playerStatus) = (collector, distributor, playerStatus);

        private void OnEnable() => _collector.OnAccumulated += Add;

        private void OnDisable() => _collector.OnAccumulated -= Add;

        public IEnumerable<IBlock> TakeOffBlocks()
        {
            _blocks.Reverse();
            IEnumerable<IBlock> blocks = _blocks;

            _blocks = new List<IBlock>();
            _collector.Clear();
            
            _playerStatus.SetNumberOfBlockInStack(0);
            
            return blocks;
        }
        
        private void Add(IBlock block)
        {
            block.Self.SetParent(_container);
            UpdateTransform(block.Self);
            Vector3 offset = new Vector3(0, block.Self.localScale.y, 0) * _blocks.Count;
            _distributor.MoveForward(block.Self, _initialPosition, offset);
            _blocks.Add(block);
            
            _playerStatus.SetNumberOfBlockInStack(_blocks.Count);
        }

        private void UpdateTransform(Transform block) =>  block.rotation = Quaternion.identity;
    }
}