using IdleActionFarm.GameplayObjects;
using System;
using UnityEngine;

namespace IdleActionFarm.Physics
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class BlockCollector : MonoBehaviour, ICollector
    {
        [SerializeField] [Min(0)] private int _maximumBlock;

        public event Action<IBlock> OnAccumulated = delegate { };

        private int _currentCount = 0;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IBlock block) == false)
                return;

            if (block.IsCollected == true)
                return;
            
            _currentCount++;
            if (_maximumBlock < _currentCount)
                return;
            
            block.Collect();
            
            OnAccumulated.Invoke(block);
        }

        public void Clear() => _currentCount = 0;
    }
}