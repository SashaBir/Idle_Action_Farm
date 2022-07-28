using System;
using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class GrassSlicer : MonoBehaviour
    {
        [SerializeField] private Vector3 _planeWorldDirection;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Grass grass) == false)
                return;

            Vector3 planeWorldPosition = transform.position;
            grass.Slice(planeWorldPosition, _planeWorldDirection);

        }
    }
}