using IdleActionFarm.GameplayObjects;
using IdleActionFarm.Physics;
using IdleActionFarm.Ui;
using UnityEngine;
using Zenject;

namespace IdleActionFarm.Di
{
    public class PlayerInstaller : MonoInstaller
    {
        [Header("Ui")] 
        [SerializeField] private UiPlayerStatus _uiPlayerStatus;
        
        [Header("Direction and Rotation")]
        [SerializeField] private Joystick _joystick;

        [Header("Grass")]
        [SerializeField] private BlockCollector blockCollector;

        [Header("Mowing")] 
        [SerializeField] private Mower _mower;

        public override void InstallBindings()
        {
            BindUiPlayerStatus();
            
            BindDirection();
            BindRotation();

            BindGrassPartCollector();

            BindMower();
        }

        private void BindUiPlayerStatus()
        {
            Container
                .Bind<UiPlayerStatus>()
                .FromInstance(_uiPlayerStatus)
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