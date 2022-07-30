using IdleActionFarm.Physics;
using UnityEngine;
using Zenject;

namespace IdleActionFarm.Di
{
    public class PlayerInstaller : MonoInstaller
    {
        [Header("Direction and Rotation")]
        [SerializeField] private Joystick _joystick;

        [Header("Grass")]
        [SerializeField] private BlockCollector blockCollector;

        public override void InstallBindings()
        {
            BindDirection();
            BindRotation();

            BindGrassPartCollector();
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

        private void BindGrassPartCollector()
        {
            Container
               .Bind<ICollector>()
               .FromInstance(blockCollector)
               .AsSingle()
               .NonLazy();
        }
    }
}