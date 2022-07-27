using UnityEngine;
using Zenject;

namespace IdleActionFarm.PhysicsMovement
{
    public class Rotation : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        private IRotation _rotation;

        [Inject]
        private void Construct(IRotation rotation) => _rotation = rotation;

        private void Update()
        {
            if (_rotation.Angle == 0f)
                return;
            
            Rotate();
        }

        private void Rotate() => _rigidbody.MoveRotation(Quaternion.Euler(new Vector3(0, _rotation.Angle, 0)));
    }
}