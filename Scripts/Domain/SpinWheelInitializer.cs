using IFuzeHostage.SpinWheel.Data;
using UnityEngine;

namespace IFuzeHostage.SpinWheel
{
    public class SpinWheelInitializer : MonoBehaviour
    {
        [SerializeField]
        private RewardDataListHolder _rewardDataList;

        [SerializeField]
        private SpinWheelView _spinWheel;
        [SerializeField]
        private SpinWheelButtonController _spinButton;

        private void Start()
        {
            _spinWheel.Open(_rewardDataList.RewardDatas);
            _spinButton.Set(FreeButtonSpin, "FREE SPIN");
        }

        private void FreeButtonSpin()
        {
            _spinWheel.StartSpin();
            _spinButton.Set(PaidButtonSpin, "SPIN FOR TICKET");
        }

        private void PaidButtonSpin()
        {
            Debug.Log("You spent a ticket");
            _spinWheel.StartSpin();
        }
    }
}