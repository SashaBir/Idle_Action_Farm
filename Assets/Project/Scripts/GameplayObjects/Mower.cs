using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace IdleActionFarm.GameplayObjects
{
    public class Mower : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] [Min(0)] private float _duration;
        [SerializeField] private ActivatorSlicer _activatorSlicer;

        private void OnEnable() => _button.onClick.AddListener(() => Mow());

        public void StopMowing() => _activatorSlicer.Disactivate();

        private async UniTaskVoid Mow()
        {
            _activatorSlicer.Activate();
            await UniTask.Delay(TimeSpan.FromSeconds(_duration));
            StopMowing();
        }
    }
}