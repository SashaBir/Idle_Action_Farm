using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    [RequireComponent(typeof(Collider))]
    public class Block : MonoBehaviour, IBlock
    {
        [field: SerializeField] public int Price { get; private set; }
        
        public bool IsCollected { get; private set; } = false;

        public Transform Self => transform;
        
        public void Collect() => IsCollected = true;
    }
}