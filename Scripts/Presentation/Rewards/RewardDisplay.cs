using IFuzeHostage.SpinWheel.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IFuzeHostage.SpinWheel.Presentation.Rewards
{
    /// <summary>
    /// A class for displaying RewardData in UI
    /// </summary>
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
        private RewardDisplayDataAdapter _dataAdapter;
        
        public void SetData(RewardData rewardData)
        {
            _dataAdapter.Set(rewardData);
        }

        public void Set(Sprite icon, string countText, string nameText)
        {
            if(_rewardIcon != null)
                _rewardIcon.sprite = icon;

            if (_nameText != null)
                _nameText.text = nameText;

            if (_countText != null)
                _countText.text = countText;
        }

        private void Awake()
        {
            _dataAdapter = new RewardDisplayDataAdapter(this);
        }
    }
}