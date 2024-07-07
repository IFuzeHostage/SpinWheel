using IFuzeHostage.SpinWheel.Data;
using UnityEngine;
using UnityEngine.UI;

namespace IFuzeHostage.SpinWheel.Presentation.Rewards
{
    public class RewardWindow : MonoBehaviour
    {
        [SerializeField]
        private RewardDisplay _rewardDisplay;
        [SerializeField]
        private Button _closeButton;
        
        public void SetReward(RewardData data)
        {
            _rewardDisplay.SetData(data);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Open(RewardData data)
        {
            Open();
            SetReward(data);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        private void Awake()
        {
            _closeButton.onClick.AddListener(Close);
        }
    }
}