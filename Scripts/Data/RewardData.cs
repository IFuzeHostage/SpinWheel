using UnityEngine;

namespace IFuzeHostage.SpinWheel.Data
{
    public class RewardData
    {
        public string Id { get; }
        public string DisplayName { get; }
        public Sprite Icon { get; }
        public float Weight { get; }

        public RewardData(string id, string displayName, Sprite icon, float weight)
        {
            this.Id = id;
            this.DisplayName = displayName;
            this.Icon = icon;
            this.Weight = weight;
        }
    }
}