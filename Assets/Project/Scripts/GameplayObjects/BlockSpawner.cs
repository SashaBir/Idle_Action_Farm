using System;
using UnityEngine;
using Zenject;

namespace IdleActionFarm.GameplayObjects
{
    [Serializable]
    public class BlockSpawner
    {
        [SerializeField] private Block _prefab;
        [SerializeField] private Transform _container;
        [SerializeField] [Range(0, 10)] private float _range;

        public DiContainer DiContainer { set; private get; }
        
        public IBlock Spawn(Vector3 position)
        {
            position.x += UnityEngine.Random.Range(-_range, _range);
            position.z += UnityEngine.Random.Range(-_range, _range);
            
            return DiContainer.InstantiatePrefabForComponent<Block>(_prefab, position, _prefab.transform.rotation, _container);
        }
    }
}