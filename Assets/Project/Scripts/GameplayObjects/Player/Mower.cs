using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using IdleActionFarm.Physics;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace IdleActionFarm.GameplayObjects
{
    public class Mower : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] [Min(0)] private float _duration;
        [SerializeField] private ActivatorSlicer _activatorSlicer;

        private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private IDirection _direction;

        [Inject]
        private void Construct(IDirection direction) => _direction = direction;
        
        private void OnEnable()
        {
            _button.onClick.AddListener(() => Mow(_tokenSource.Token));
            _direction.OnStartedDirection += StopMowing;
        }

        private void OnDisable() => _direction.OnStartedDirection -= StopMowing;

        private async UniTaskVoid Mow(CancellationToken token)
        {
            _button.gameObject.SetActive(false);
            _activatorSlicer.Activate();
            await UniTask.Delay(TimeSpan.FromSeconds(_duration), cancellationToken: token);
            StopMowing();
        }

        public void StopMowing()
        {
            _tokenSource.Cancel();
            _button.gameObject.SetActive(true);
            _activatorSlicer.Disactivate();
        }
    }
}