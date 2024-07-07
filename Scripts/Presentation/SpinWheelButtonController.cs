using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IFuzeHostage.SpinWheel
{
    public class SpinWheelButtonController : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private TextMeshProUGUI _text;
        
        public void Set(Action clickAction, string buttonText)
        {
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => clickAction?.Invoke());
            _text.text = buttonText;
        }

        public void SetEnabled(bool isEnabled)
        {
            _button.interactable = isEnabled;
        }
    }
}