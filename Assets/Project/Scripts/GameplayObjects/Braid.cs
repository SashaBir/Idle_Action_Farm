using System;
using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Braid : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out Grass grass) == false)
                return;

            Vector3 planeWorldPosition = transform.position;
            Vector3 planeWorldDirection = -collision.contacts[0].normal;
            
            grass.Slice(planeWorldPosition, planeWorldDirection);
        }
    }
}