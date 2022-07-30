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

        private Queue<GameObject> _stacks = new Queue<GameObject>();
        private ICollector _collector;
        private BlockDistributor _distributor;

        [Inject]
        private void Constructor(ICollector collector, BlockDistributor distributor) => 
            (_collector, _distributor) = (collector, distributor);

        private void OnEnable() => _collector.OnAccumulated += Add;

        private void OnDisable() => _collector.OnAccumulated -= Add;

        private void Add(Transform block)
        {
            block.SetParent(_container);
            
            Vector3 offset = new Vector3(0, block.transform.lossyScale.y, 0) * _stacks.Count;
            _distributor.MoveAlongTrajectory(block, () => _initialPosition.position + offset);
            _stacks.Enqueue(block.gameObject);
            
            print(_initialPosition.position + offset);
        }
    }
}