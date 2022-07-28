using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    [RequireComponent(typeof(Rigidbody))]
    public class GrassPart : MonoBehaviour
    {
        public void Collect()
        {
            print("Collected");
            Destroy(gameObject);
        }
    }
}