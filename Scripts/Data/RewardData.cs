using System;
using UnityEngine;

namespace IFuzeHostage.SpinWheel.Data
{
    [Serializable]
    public class RewardData
    {
        [field: SerializeField]
        public string Id { get; private set; }
        [field: SerializeField]
        public string DisplayName { get; private set; }
        [field: SerializeField]
        public Sprite Icon { get;  private set; }
        [field: SerializeField]
        public float Weight { get;  private set; }

        public RewardData(string id, string displayName, Sprite icon, float weight)
        {
            this.Id = id;
            this.DisplayName = displayName;
            this.Icon = icon;
            this.Weight = weight;
        }
    }
}