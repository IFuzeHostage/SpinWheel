using UnityEngine;

namespace IFuzeHostage.SpinWheel.Data.Entity
{
    public abstract class RewardDataEntry : ScriptableObject
    {
        public abstract RewardData Data { get; }
    }
}