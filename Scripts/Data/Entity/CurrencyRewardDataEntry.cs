using UnityEngine;

namespace IFuzeHostage.SpinWheel.Data.Entity
{
    [CreateAssetMenu(menuName = "IFuzeHostage/SpinWheel/Currency Reward Data Entry", fileName = "currency_reward_data_entry")]
    public class CurrencyRewardDataEntry : RewardDataEntry
    {
        public override RewardData Data => _itemRewardData;
        
        [SerializeField]
        private CurrencyRewardData _itemRewardData;
    }
}