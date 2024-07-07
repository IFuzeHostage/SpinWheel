using System;
using System.Collections.Generic;
using System.Linq;
using IFuzeHostage.SpinWheel.Data.Entity;
using UnityEngine;

namespace IFuzeHostage.SpinWheel.Data
{
    [Serializable]
    public class SpinWheelRewardsData
    {
        public List<RewardData> InitialRewards => _initialRewards.Select(entry => entry.Data).ToList();
        public List<RewardData> ReplacementRewards => _replacementRewards.Select(entry => entry.Data).ToList();
        public List<RewardData> GuaranteedRewards => _guaranteedRewards.Select(entry => entry.Data).ToList();
        
        [SerializeField]
        public List<RewardDataEntry> _initialRewards;
        [SerializeField]
        public List<RewardDataEntry> _replacementRewards;
        [SerializeField]
        public List<RewardDataEntry> _guaranteedRewards;
    }
}