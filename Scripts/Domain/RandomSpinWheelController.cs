using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFuzeHostage.SpinWheel.Data;
using IFuzeHostage.SpinWheel.Utilities;

namespace IFuzeHostage.SpinWheel
{
    internal class RandomSpinWheelController : ISpinWheelController
    {
        public Action OnInitialized { get; set; }
        
        private List<RewardData> _rewardDatas;
        
        public RandomSpinWheelController(List<RewardData> rewardDatas)
        {
            _rewardDatas = rewardDatas;
        }
        
        public void Init()
        {
            OnInitialized?.Invoke();
        }

        public Task<List<RewardData>> GetRewardList()
        {
            return Task.FromResult(_rewardDatas);
        }

        public Task<RewardData> GetRandomReward()
        {
            if (_rewardDatas.Count <= 0)
            {
                return Task.FromException<RewardData>(new IndexOutOfRangeException("SpinWheel: Reward list is empty"));
            }

            var randomItem = WeightedRandom.GetItem<RewardData>(_rewardDatas.Select(
                data => new WeightedItem<RewardData>(data, data.Weight)));

            return Task.FromResult(randomItem);
        }
    }
}