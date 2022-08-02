using TMPro;
using UnityEngine;

namespace IdleActionFarm.Ui
{
    public class UiPlayerStatus : MonoBehaviour
    {
        [SerializeField] private TMP_Text _money;
        [SerializeField] private TMP_Text _numberOfBlockInStack;

        public void SetMoney(int value) => _money.text = value.ToString();
        
        public void SetNumberOfBlockInStack(int value) => _numberOfBlockInStack.text = value.ToString();
    }
}