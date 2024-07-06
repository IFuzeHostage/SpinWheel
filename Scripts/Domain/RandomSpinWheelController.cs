using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IFuzeHostage.SpinWheel.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace IFuzeHostage.SpinWheel
{
    internal class RandomSpinWheelController : ISpinWheelController
    {
        private List<RewardData> _rewardDatas;
        
        public RandomSpinWheelController(List<RewardData> rewardDatas)
        {
            _rewardDatas = rewardDatas;
        }
        
        public void Init()
        {
            
        }

        public List<RewardData> GetRewardList()
        {
            return _rewardDatas;
        }

        public Task<RewardData> GetRandomReward()
        {
            if (_rewardDatas.Count <= 0)
            {
                return Task.FromException<RewardData>(new IndexOutOfRangeException("SpinWheel: Reward list is empty"));
            }
            
            int randomIndex = Random.Range(0, _rewardDatas.Count);
            RewardData selectedData = _rewardDatas[randomIndex];

            return Task.FromResult(selectedData);
        }
    }
}