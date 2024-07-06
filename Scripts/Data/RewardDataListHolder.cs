using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IFuzeHostage.SpinWheel.Data
{
    [CreateAssetMenu(menuName = "IFuzeHostage/SpinWheel/Reward Data List", fileName = "reward_data_list")]
    public class RewardDataListHolder : ScriptableObject
    {
        public List<RewardData> RewardDatas => _rewards;
        
        [SerializeField]
        private List<RewardData> _rewards;
    }   
}
