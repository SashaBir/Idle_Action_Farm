using IdleActionFarm.GameplayObjects;
using UnityEngine;
using UnityEngine.UI;

namespace IdleActionFarm.Physics
{
    public class Mower : MonoBehaviour
    {
        [SerializeField] private Button _button; 
        [SerializeField] private GrassSlicer _grassSlicer;

        private void Awake()
        {
            _button.onClick.AddListener(() =>
            {
                _grassSlicer.gameObject.SetActive(true);
            });
        }
    }
}