using IdleActionFarm.GameplayObjects;
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

        [Header("Mowing")] 
        [SerializeField] private Mower _mower;

        public override void InstallBindings()
        {
            BindDirection();
            BindRotation();

            BindGrassPartCollector();

            BindMower();
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

        private void BindMower()
        {
            Container
                .Bind<Mower>()
                .FromInstance(_mower)
                .AsSingle()
                .NonLazy();
        }
    }
}