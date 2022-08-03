using IdleActionFarm.GameplayObjects;
using IdleActionFarm.Physics;
using UnityEngine;
using Zenject;

namespace IdleActionFarm.Di
{
    public class PlayerInstaller : MonoInstaller
    {
        [Header("Ui")] 
        [SerializeField] private PlayerStatus _playerStatus;
        
        [Header("Input System")]
        [SerializeField] private Joystick _joystick;

        [Header("Grass")]
        [SerializeField] private BlockCollector blockCollector;

        [Header("Mowing")] 
        [SerializeField] private Mower _mower;

        public override void InstallBindings()
        {
            BindPlayerStatus();
            
            BindDirection();
            BindRotation();

            BindGrassPartCollector();

            BindMower();
        }

        private void BindPlayerStatus()
        {
            Container
                .Bind<PlayerStatus>()
                .FromInstance(_playerStatus)
                .AsSingle()
                .NonLazy();
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