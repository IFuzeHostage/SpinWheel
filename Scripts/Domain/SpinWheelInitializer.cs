﻿using IFuzeHostage.SpinWheel.Data;
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
            _spinWheel.StartSpin();
            _spinButton.Set(PaidButtonSpin, "SPIN FOR TICKET");
        }

        private void PaidButtonSpin()
        {
            Debug.Log("You spent a ticket");
            _spinWheel.StartSpin();
        }
        
        private void OnWheelStopped(RewardData reward)
        {
            _rewardWindow.Open(reward);
        }
    }
}
