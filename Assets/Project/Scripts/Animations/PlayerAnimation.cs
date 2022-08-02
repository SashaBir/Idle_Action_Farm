using System;
using UnityEngine;

namespace IdleActionFarm.Animations
{
    [Serializable]
    public class PlayerAnimation
    {
        [SerializeField] private Animator _animator;

        private readonly int _running = Animator.StringToHash("Running");
        private readonly int _mowing = Animator.StringToHash("Mowing");

        public void PlayRunning() => _animator.SetBool(_running, true);

        public void StopRunning() => _animator.SetBool(_running, false);
        
        public void PlayerMowing() => _animator.SetTrigger(_mowing);
    }
}