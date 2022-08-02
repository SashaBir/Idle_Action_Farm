using System;
using UnityEngine;
using Zenject;

namespace IdleActionFarm.Physics
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private SurfaceSlider _slider;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;

        private IDirection _direction;

        [Inject]
        private void Construct(IDirection direction) => _direction = direction;
        
        private void Update()
        {
            if (_direction.Direction == Vector2.zero)
                return;

            Move();
        }

        private void Move()
        {
            var directionAlongSurface = _slider.Project(_direction.Direction);
            var offset = directionAlongSurface * (_speed * Time.fixedDeltaTime);

            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }
}