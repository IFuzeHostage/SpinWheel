using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFuzeHostage.SpinWheel.Data;
using IFuzeHostage.SpinWheel.Utilities;
using Random = UnityEngine.Random;

namespace IFuzeHostage.SpinWheel.Domain
{
    /// <summary>
    /// Default implementation of ISPinWheelController. Generates Random reward based on provided weight. 
    /// Works with guaranteed rewards and replaces dropped rewards with other ones.
    /// </summary>
    internal class RandomSpinWheelController : ISpinWheelController
    {
        public Action OnInitialized { get; set; }

        private List<RewardData> _activeRewards;
        private List<RewardData> _replacementRewards;
        private List<RewardData> _guaranteedRewards;
        
        private SpinWheelRewardsData _rewardData;
        
        public RandomSpinWheelController(SpinWheelRewardsData rewardData)
        {
            _rewardData = rewardData;

            _activeRewards = new List<RewardData>(rewardData.InitialRewards);
            _replacementRewards = new List<RewardData>(rewardData.ReplacementRewards);
            _guaranteedRewards = new List<RewardData>(rewardData.GuaranteedRewards);
        }
        
        public void Init()
        {
            OnInitialized?.Invoke();
        }

        public Task<List<RewardData>> GetRewardList()
        {
            return Task.FromResult(_activeRewards);
        }

        public Task<RewardData> GetRandomReward()
        {
            if (_guaranteedRewards.Count > 0 && _activeRewards.Contains(_guaranteedRewards[0]))
            {
                ShiftRewards(_guaranteedRewards[0]);
                return Task.FromResult(_guaranteedRewards[0]);
            }
            
            if (_activeRewards.Count <= 0)
            {
                return Task.FromException<RewardData>(new IndexOutOfRangeException("SpinWheel: Reward list is empty"));
            }

            var randomItem = WeightedRandom.GetItem<RewardData>(_activeRewards.Select(
                data => new WeightedItem<RewardData>(data, data.Weight)));

            ShiftRewards(randomItem);

            return Task.FromResult(randomItem);
        }

        private void ShiftRewards(RewardData grantedItem)
        {
            RewardData replacementReward = _replacementRewards[Random.Range(0, _replacementRewards.Count)];
            
            _replacementRewards.Remove(replacementReward);
            
            if(grantedItem is not ItemRewardData { CanGetMultiple: true })
                _replacementRewards.Add(grantedItem);

            if (_activeRewards.Contains(grantedItem))
            {
                _activeRewards[_activeRewards.IndexOf(grantedItem)] = replacementReward;
            }
            else
            {
                _activeRewards.Add(replacementReward);
                _activeRewards.Remove(grantedItem);
            }
            
        }
    }
}