using IdleActionFarm.GameplayObjects;
using UnityEngine;
using Zenject;

namespace IdleActionFarm.Di
{
    public class BlockInstaller : MonoInstaller
    {
        [SerializeField] private BlockSpawner _blockSpawner;
        [SerializeField] private BlockDistributor _blockDistributor;
        
        public override void InstallBindings()
        {
            BindBlockSpawner();
            BindBlockDistributor();
        }

        private void BindBlockSpawner()
        {
            Container
                .Bind<BlockSpawner>()
                .FromInstance(_blockSpawner)
                .AsSingle()
                .NonLazy();

            _blockSpawner.DiContainer = Container;
        }

        private void BindBlockDistributor()
        {
            Container
                .Bind<BlockDistributor>()
                .FromInstance(_blockDistributor)
                .AsSingle()
                .NonLazy();
        }
    }
}