using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace IdleActionFarm.GameplayObjects
{
    [RequireComponent(typeof(Collider))]
    public class Grass : MonoBehaviour, ISliceable
    {
        [SerializeField] private GameObject _greenery;
        [SerializeField] private ParticleSystem _slicedEffect;
        [SerializeField] [Min(0)] private float _reloadeTime;

        private BlockSpawner _spawner;
        private TimeSpan _reloaded;

        public bool AlreadySliced { get; private set; } = false;
        
        [Inject]
        private void Construct(BlockSpawner spawner) => _spawner = spawner;
        
        private void Awake() => _reloaded = TimeSpan.FromSeconds(_reloadeTime);

        public void Slice()
        {
            _spawner.Spawn(transform.position);
            
            TurnOff();
            UniTask.Create(async () =>
            {
                await UniTask.Delay(_reloaded);
                TurnOn();
            });
        }
        
        private void TurnOn() => Turn(false, true);

        private void TurnOff() => Turn(true, false);
        
        private void Turn(bool alreadySliced, bool greenyAcivate)
        {
            AlreadySliced = alreadySliced;
            _greenery.SetActive(greenyAcivate);
            _slicedEffect.Play();
        }
    }
}