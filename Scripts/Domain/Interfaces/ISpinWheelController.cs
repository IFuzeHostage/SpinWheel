using System.Collections.Generic;
using System.Threading.Tasks;
using IFuzeHostage.SpinWheel.Data;

namespace IFuzeHostage.SpinWheel
{
    public interface ISpinWheelController
    {
        public void Init();
        public List<RewardData> GetRewardList();
        public Task<RewardData> GetRandomReward();
    }
}
