using System;
using UnityEngine;

namespace IFuzeHostage.SpinWheel.Data
{
    [Serializable]
    public class CurrencyRewardData : RewardData
    {
        [field: SerializeField]
        public int Count { get; private set; }
        
        public CurrencyRewardData(string id, string displayName, Sprite icon, float weight, int count) : base(id, displayName, icon, weight)
        {
            Count = count;
        }
    }
}