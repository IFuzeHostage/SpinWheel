using IFuzeHostage.SpinWheel.Data;
using IFuzeHostage.SpinWheel.Data.Entity;
using IFuzeHostage.SpinWheel.Presentation.Rewards;
using IFuzeHostage.SpinWheel.Presentation.SpinWheel;
using UnityEngine;

namespace IFuzeHostage.SpinWheel.Domain
{
    /// <summary>
    /// Mostly Sample class with initialization example for SpinWheel
    /// </summary>
    public class SpinWheelInitializer : MonoBehaviour
    {
        [SerializeField]
        private RewardDataListHolder _rewardDataList;

        [SerializeField]
        private SpinWheelView _spinWheel;
        [SerializeField]
        private RewardWindow _rewardWindow;
        [SerializeField]
        private SpinWheelButtonController _spinButton;

        private void Start()
        {
            _spinWheel.OnWheelStopped += OnWheelStopped;
            _spinWheel.Open(_rewardDataList.RewardData);
            _spinButton.Set(FreeButtonSpin, "FREE SPIN");
        }


        private void FreeButtonSpin()
        {
            _spinButton.SetEnabled(false);
            _spinWheel.StartSpin();
            _spinButton.Set(PaidButtonSpin, "SPIN FOR TICKET");
        }

        private void PaidButtonSpin()
        {
            Debug.Log("You spent a ticket");
            _spinButton.SetEnabled(false);
            _spinWheel.StartSpin();
        }
        
        private void OnWheelStopped(RewardData reward)
        {
            _spinButton.SetEnabled(true);
            _rewardWindow.Open(reward);
        }
    }
}
