using UnityEngine;

namespace IdleActionFarm.PhysicsMovement
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class SurfaceSlider : MonoBehaviour
    {
        private Vector3 _normal = Vector3.zero;

        private void OnCollisionEnter(Collision collision) => _normal = collision.contacts[0].normal;

        public Vector3 Project(Vector3 direction)
        {
            Vector3 newDirection = new Vector3(direction.x, 0, direction.y);
            return newDirection - Vector3.Dot(_normal, newDirection) * _normal;
        }
    }
}