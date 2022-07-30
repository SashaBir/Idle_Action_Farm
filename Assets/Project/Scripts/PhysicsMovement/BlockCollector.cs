using IdleActionFarm.GameplayObjects;
using System;
using UnityEngine;

namespace IdleActionFarm.Physics
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class BlockCollector : MonoBehaviour, ICollector
    {
        [SerializeField][Min(0)] private int _maximumBlock;

        public event Action<Transform> OnAccumulated = delegate { };

        private int _currentCount = 0;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICollectable collectable) == false)
                return;

            if (collectable.IsCollected == true)
                return;
            
            if (_maximumBlock < _currentCount)
                return;
            
            collectable.Collect();
            
            _currentCount++;
            OnAccumulated.Invoke(other.transform);
        }
    }
}