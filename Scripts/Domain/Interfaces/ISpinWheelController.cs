using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IFuzeHostage.SpinWheel.Data;

namespace IFuzeHostage.SpinWheel
{
    /// <summary>
    /// Interface for Spin Wheel's reward processing
    /// Extend it to run SpinWheel with your own logic of providing and selecting rewards
    /// </summary>
    public interface ISpinWheelController
    {
        public Action OnInitialized { get; set; }
        public void Init();
        public Task<List<RewardData>> GetRewardList();
        public Task<RewardData> GetRandomReward();
    }
}
