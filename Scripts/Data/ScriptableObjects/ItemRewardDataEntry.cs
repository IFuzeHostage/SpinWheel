using UnityEngine;

namespace IFuzeHostage.SpinWheel.Data
{
    [CreateAssetMenu(menuName = "IFuzeHostage/SpinWheel/Item Reward Data Entry", fileName = "item_reward_data_entry")]
    public class ItemRewardDataEntry : RewardDataEntry
    {
        public override RewardData Data => _itemRewardData;

        [SerializeField]
        private ItemRewardData _itemRewardData;
    }
}