using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace IdleActionFarm.GameplayObjects
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class ReceivingBlock : MonoBehaviour
    {
        [SerializeField] private Transform _point;
        [SerializeField] [Min(0)] private float _durationBetweenBlocks;
        [SerializeField] [Min(0)] private float _durationDestoyedBlockAfterReceived;
        
        private BlockDistributor _blockDistributor;
        private TimeSpan _time;

        [Inject]
        private void Construct(BlockDistributor blockDistributor) =>
            _blockDistributor = blockDistributor;

        private void Awake() => _time = TimeSpan.FromSeconds(_durationBetweenBlocks);

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Porter porter) == false)
                return;

            Move(porter.Blocks);
            
        }

        private async UniTaskVoid Move(IEnumerable<GameObject> blocks)
        {
            foreach (var block in blocks)
            {
                await UniTask.Delay(_time);
                
                _blockDistributor.MoveForward(block.transform, _point, Vector3.zero);
                Destroy(block, _durationDestoyedBlockAfterReceived);
            }
        }
    }
}