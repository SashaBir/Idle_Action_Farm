using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using IdleActionFarm.Physics;
using UnityEngine;
using Zenject;

namespace IdleActionFarm.GameplayObjects
{
    public class PorterShaker : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private float _duration;
        [SerializeField] private float _minimumAngle;
        [SerializeField] private float _maximumAngle;

        private Tween _tween;
        private IDirection _direction;

        private bool _isForward = true;
        
        [Inject]
        private void Construct(IDirection direction) => _direction = direction;

        private void OnEnable()
        {
            _direction.OnStartedDirection += StartRotate;
            _direction.OnEndedDirection += StopRotate;
        }

        private void OnDisable()
        {
            _direction.OnStartedDirection -= StartRotate;
            _direction.OnEndedDirection -= StopRotate;
        }

        private void StartRotate()
        {
            /*
            StartRotateAsync().Forget();
            */
        }

        private async UniTaskVoid StartRotateAsync()
        {
            /*
            do
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_duration));
                
                _tween = _isForward == true
                    ? _container.DOLocalRotate(new Vector3(0, 0, _maximumAngle), _duration)
                    : _container.DOLocalRotate(new Vector3(0, 0, _minimumAngle), _duration);

                _isForward = !_isForward;
            }
            while (_tween.IsActive() == true);
            */
        }

        private void StopRotate()
        {
            _tween.Kill(); 
            // 0.2f - time to return to initial point
            _tween = _container.DOLocalRotate(Vector3.zero,0.2f);
        }
    }
}