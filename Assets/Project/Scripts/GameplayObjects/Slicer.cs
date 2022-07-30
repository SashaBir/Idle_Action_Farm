using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Slicer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ISliceable sliceable) == false)
                return;

            if (sliceable.AlreadySliced == true)
                return;

            sliceable.Slice();
        }
    }
}