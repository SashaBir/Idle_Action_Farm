using System;
using IdleActionFarm.GameplayObjects;
using IdleActionFarm.Physics;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace IdleActionFarm.Animations
{
    public class PlayerAnimationPresenter : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private PlayerAnimation _animation;

        private Mower _mower;
        private IDirection _direction;

        [Inject]
        private void Construct(Mower mower, IDirection direction) => 
            (_mower, _direction) = (mower, direction);

        private void OnEnable() => _button.onClick.AddListener(_animation.PlayerMowing);

        private void OnDisable() => _button.onClick.RemoveListener(_animation.PlayerMowing);

        private void Update()
        {
            if (_direction.Direction == Vector2.zero)
            {
                _animation.StopRunning();
                return;
            }

            _mower.StopMowing();
            _animation.PlayRunning();
        }
    }
}