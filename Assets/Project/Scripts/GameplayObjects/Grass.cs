using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    public class Grass : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _maximumSliced;

        private int _countSliced = 0;
        
        public void Slice(Vector3 planeWorldPosition, Vector3 planeWorldDirection)
        {
            if (_countSliced >= _maximumSliced)
            {
                Destroy(gameObject);
                return;
            }

            _countSliced++;
        }
    }
}