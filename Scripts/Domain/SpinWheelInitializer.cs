using IFuzeHostage.SpinWheel.Data;
using UnityEngine;

namespace IFuzeHostage.SpinWheel
{
    public class SpinWheelInitializer : MonoBehaviour
    {
        [SerializeField]
        private RewardDataListHolder _rewardDataList;

        [SerializeField]
        private SpinWheelView _spinWheel;

        private void Start()
        {
            _spinWheel.Open(_rewardDataList.RewardDatas);
        }
    }
}