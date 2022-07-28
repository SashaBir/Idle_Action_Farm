using IdleActionFarm.Physics;
using UnityEngine;
using Zenject;

namespace IdleActionFarm.Di
{
    public class PlayerInstaller : MonoInstaller
    {
        [Header("Direction and Rotation")]
        [SerializeField] private Joystick _joystick;
        
        public override void InstallBindings()
        {
            BindDirection();
            BindRotation();
        }

        private void BindDirection()
        {
            Container
                .Bind<IDirection>()
                .FromInstance(_joystick)
                .AsSingle()
                .NonLazy();
        }

        private void BindRotation()
        {
            Container
                .Bind<IRotation>()
                .FromInstance(_joystick)
                .AsSingle()
                .NonLazy();
        }
    }
}