using UnityEngine;

namespace IdleActionFarm.PhysicsMovement
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class SurfaceSlider : MonoBehaviour
    {
        private Vector3 _normal = Vector3.zero;

        private void OnCollisionEnter(Collision collision) => _normal = collision.contacts[0].normal;

        public Vector3 Project(Vector3 direction) => direction - Vector3.Dot(_normal, direction) * _normal;
    }
}