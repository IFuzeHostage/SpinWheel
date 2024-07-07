using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IFuzeHostage.SpinWheel.Data.Entity
{
    [CreateAssetMenu(menuName = "IFuzeHostage/SpinWheel/Reward Data List", fileName = "reward_data_list")]
    public class RewardDataListHolder : ScriptableObject
    {
        public SpinWheelRewardsData RewardData => _rewards;
        
        [SerializeField]
        private SpinWheelRewardsData _rewards;
    }   
}
