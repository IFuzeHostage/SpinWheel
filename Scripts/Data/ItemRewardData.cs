using System;
using UnityEngine;

namespace IFuzeHostage.SpinWheel.Data
{
    [Serializable]
    public class ItemRewardData : RewardData
    {
        [field: SerializeField]
        public bool CanGetMultiple { get; private set; }
        
        public ItemRewardData(string id, string displayName, Sprite icon, float weight, bool canGetMultiple) : base(id, displayName, icon, weight)
        {
            CanGetMultiple = canGetMultiple;
        }
    }
}