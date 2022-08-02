using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using IdleActionFarm.Ui;
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
        private UiPlayerStatus _uiPlayerStatus;
        private TimeSpan _time;

        [Inject]
        private void Construct(BlockDistributor blockDistributor, UiPlayerStatus uiPlayerStatus) =>
            (_blockDistributor, _uiPlayerStatus) = (blockDistributor, uiPlayerStatus);

        private void Awake() => _time = TimeSpan.FromSeconds(_durationBetweenBlocks);

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Porter porter) == false)
                return;

            Move(porter.TakeOffBlocks());
            
        }

        private async UniTaskVoid Move(IEnumerable<IBlock> blocks)
        {
            var array = blocks.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                await UniTask.Delay(_time);
                
                var block = array[i].Self;
                _blockDistributor.MoveForward(block, _point, Vector3.zero);
                Destroy(block.gameObject, _durationDestoyedBlockAfterReceived);
                
                _uiPlayerStatus.SetNumberOfBlockInStack(array.Length - i - 1);
            }
        }
    }
}