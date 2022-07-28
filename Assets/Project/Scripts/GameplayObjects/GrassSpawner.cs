using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    [Serializable]
    public class GrassSpawner : MonoBehaviour
    {
        [SerializeField] private Grass _grass;
        [SerializeField] private Transform _initialPosition;
        [SerializeField] private Transform _container;
        [SerializeField] private int _lenght;
        [SerializeField] private int _width;
        [SerializeField] private Vector3 _offset;
        [SerializeField] [Min(0)] private float _timeReloaded;

        private void Awake() => Spawn();

        private void Spawn()
        {
            Vector3 position = _initialPosition.position;
            for (int i = 0; i < _lenght; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Grass grass = CreateGrass(position);
                    Respawn(grass);
                    position.x += _offset.x;
                }

                position.x = _initialPosition.position.x;
                position.z += _offset.z;
            }
        }

        private async UniTaskVoid Respawn(Grass grass)
        {
            Vector3 position = grass.transform.position;
            await UniTask.WaitWhile(() => grass != null);
            await UniTask.Delay(TimeSpan.FromSeconds(_timeReloaded));

            Grass createdGrass = CreateGrass(position);
            Respawn(createdGrass);
        }
        
        private Grass CreateGrass(Vector3 position) => Instantiate(_grass, position, _grass.transform.rotation, _container);
    }
}