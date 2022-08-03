using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    public class PlayerStatus : MonoBehaviour
    {
        [Header("Texts")]
        [SerializeField] private TMP_Text _money;
        [SerializeField] private TMP_Text _numberOfBlockInStack;

        [Header("Animations Moneys")]
        [SerializeField] private RectTransform _desingMoney;
        [SerializeField] private RectTransform _inital;
        [SerializeField] private RectTransform _final;
        [SerializeField] [Min(0)] private float _duration;

        [Header("Vibration Money")]
        [SerializeField] private RectTransform _vibrationMoney;
        [SerializeField] [Min(0)] private float _vibrationDuration;
        [SerializeField] [Min(0)] private float _vibrationStrenght;

        private Tween _tween;
        private int _numberOfmoney = 0;

        public void AddMoney(int value) => _money.text = (_numberOfmoney += value).ToString();
        
        public void SetNumberOfBlockInStack(int value) => _numberOfBlockInStack.text = value.ToString();

        public async UniTaskVoid AnimateMoney()
        {
            _tween.Kill();
            
            _desingMoney.gameObject.SetActive(true);
            _desingMoney.anchoredPosition = _inital.anchoredPosition;
            _desingMoney.DOMove(_final.transform.position, _duration);

            await UniTask.Delay(TimeSpan.FromSeconds(_duration));
            
            _desingMoney.gameObject.SetActive(false);
            _vibrationMoney.DOShakePosition(_vibrationDuration, _vibrationStrenght);
        }
    }
}