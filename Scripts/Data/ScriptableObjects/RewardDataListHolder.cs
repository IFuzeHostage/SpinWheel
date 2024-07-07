using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IFuzeHostage.SpinWheel.Data
{
    [CreateAssetMenu(menuName = "IFuzeHostage/SpinWheel/Reward Data List", fileName = "reward_data_list")]
    public class RewardDataListHolder : ScriptableObject
    {
        public List<RewardData> RewardDatas => _rewards.Select(entry => entry.Data).ToList();
        
        [SerializeField]
        private List<RewardDataEntry> _rewards;
    }   
}
