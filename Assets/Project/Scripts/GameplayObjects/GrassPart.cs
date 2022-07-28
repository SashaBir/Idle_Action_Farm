using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    [RequireComponent(typeof(Rigidbody))]
    public class GrassPart : MonoBehaviour
    {
        public void Collect() => Destroy(gameObject); 
    }
}