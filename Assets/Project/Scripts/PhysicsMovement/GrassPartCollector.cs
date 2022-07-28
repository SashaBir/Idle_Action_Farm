using IdleActionFarm.GameplayObjects;
using UnityEngine;

namespace IdleActionFarm.Physics
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class GrassPartCollector : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out GrassPart part) == false)
                return;
            
            part.Collect();
        }
    }
}