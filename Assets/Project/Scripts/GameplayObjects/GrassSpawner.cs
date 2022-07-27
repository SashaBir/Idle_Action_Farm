using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    public class GrassSpawner : MonoBehaviour
    {
        [SerializeField] private Grass _grass;
        [SerializeField] [Min(0)] private float _timeReloaded;
    }
}