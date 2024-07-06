using IFuzeHostage.SpinWheel.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IFuzeHostage.SpinWheel
{
    public class RewardDisplay : MonoBehaviour
    {
        public RectTransform RectTransform
        {
            get
            {
                if (_rect == null)
                    _rect = GetComponent<RectTransform>();

                return _rect;
            }
        }
        
        [SerializeField]
        private Image _rewardIcon;
        [SerializeField]
        private TextMeshProUGUI _countText;
        [SerializeField]
        private TextMeshProUGUI _nameText;

        private RectTransform _rect;
        
        public void SetData(RewardData rewardData)
        {
            if(_rewardIcon != null)
                _rewardIcon.sprite = rewardData.Icon;

            if (_nameText != null)
                _nameText.text = rewardData.DisplayName;

            if (_countText != null)
                _countText.text = $"1x";
        }
    }
}