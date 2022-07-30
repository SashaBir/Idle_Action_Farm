using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace IdleActionFarm.GameplayObjects
{
    [Serializable]
    public class VegetationSpawner : MonoBehaviour
    {
        [SerializeField] private Grass _grass;
        [SerializeField] private Transform _initialPosition;
        [SerializeField] private Transform _container;
        [SerializeField] private int _lenght;
        [SerializeField] private int _width;
        [SerializeField] private Vector3 _offset;

        private DiContainer _diContainer;

        [Inject]
        private void Construct(DiContainer diContainer) => _diContainer = diContainer;
        
        private void Awake() => Spawn();

        private void CreateGrass(Vector3 position) => _diContainer.InstantiatePrefab(_grass, position, _grass.transform.rotation, _container);

        private void Spawn()
        {
            Vector3 position = _initialPosition.position;
            for (int i = 0; i < _lenght; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    CreateGrass(position);
                    position.x += _offset.x;
                }

                position.x = _initialPosition.position.x;
                position.z += _offset.z;
            }
        }
    }
}