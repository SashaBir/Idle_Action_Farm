using System;
using System.Collections.Generic;
using System.Linq;
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
        private PlayerStatus _playerStatus;
        private TimeSpan _time;

        [Inject]
        private void Construct(BlockDistributor blockDistributor, PlayerStatus playerStatus) =>
            (_blockDistributor, this._playerStatus) = (blockDistributor, playerStatus);

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
                
                var block = array[i];
                _playerStatus.AddMoney(block.Price);
                _blockDistributor.MoveForward(block.Self, _point, Vector3.zero);
                Destroy(block.Self.gameObject, _durationDestoyedBlockAfterReceived);
                
                _playerStatus.SetNumberOfBlockInStack(array.Length - i - 1);
            }

            if (array.Length <= 0)
                return;
            
            _playerStatus.AnimateMoney();
        }
    }
}