using System;
using IdleActionFarm.Physics;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace IdleActionFarm.GameplayObjects
{
    public class Porter : MonoBehaviour
    {
        [SerializeField] private Transform _initialPosition;
        [SerializeField] private Transform _container;

        private List<GameObject> _blocks = new List<GameObject>();
        private ICollector _collector;
        private BlockDistributor _distributor;

        [Inject]
        private void Constructor(ICollector collector, BlockDistributor distributor) => 
            (_collector, _distributor) = (collector, distributor);

        private void OnEnable() => _collector.OnAccumulated += Add;

        private void OnDisable() => _collector.OnAccumulated -= Add;

        public IEnumerable<GameObject> Blocks
        {
            get
            {
                _blocks.Reverse();
                IEnumerable<GameObject> blocks = _blocks;

                _blocks = new List<GameObject>();
                _collector.Clear();
                
                return blocks;
            }
        }
        
        private void Add(Transform block)
        {
            Vector3 offset = new Vector3(0, block.localScale.y, 0) * _blocks.Count;
            _distributor.MoveAlongTrajectory(block, _initialPosition, offset);
            _blocks.Add(block.gameObject);
            
            block.SetParent(_container);
        }
    }
}