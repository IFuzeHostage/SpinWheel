using UnityEngine;

namespace IFuzeHostage.SpinWheel.Data
{
    public abstract class RewardDataEntry : ScriptableObject
    {
        public abstract RewardData Data { get; }
    }
}