using System.Collections.Generic;
using System.Threading.Tasks;
using IFuzeHostage.SpinWheel.Data;
using IFuzeHostage.SpinWheel.Utilities;
using UnityEngine;

namespace IFuzeHostage.SpinWheel.Presentation.SpinWheel
{
    internal class SpinWheelPresenter : ISpinWheelPresenter
    {
        private SpinWheelView _view;
        private ISpinWheelController _controller;

        private List<RewardData> _rewardDatas;
        
        public void Construct(ISpinWheelController controller)
        {
            _controller = controller;
            _controller.OnInitialized += OnControllerInitialized;
            _controller.Init();
        }

        public void SetView(SpinWheelView view)
        {
            _view = view;
        }

        public void OnOpen()
        {
            _view.OnWheelStopped += OnWheelStopped;
        }

        public void OnClose()
        {
            
        }

        public void SpinStarted()
        {
            WaitForReward().Wait();
        }
        
        private void OnControllerInitialized()
        {
            BuildWheelSlices();
        }

        private async void BuildWheelSlices()
        {
            _view.ClearWheelSlices();
            
            _rewardDatas = new List<RewardData>(await _controller.GetRewardList());

            for (int i = 0; i < _rewardDatas.Count; i++)
            {
                RewardData reward = _rewardDatas[i];
                float offset = (float) i / _rewardDatas.Count * CircleUtilities.CIRCLE_DEGREES;
                float angle = (float) 1 / _rewardDatas.Count * CircleUtilities.CIRCLE_DEGREES;
                
                _view.AddWheelSlice(reward, -offset, angle);
            }
        }

        private async Task<RewardData> WaitForReward()
        {
            _view.StartSpinAnimation();
            RewardData rewardData = await _controller.GetRandomReward();

            float offset = (float) _rewardDatas.IndexOf(rewardData) / _rewardDatas.Count;
            float angle = (float) 1 / _rewardDatas.Count;

            var randomOffset = Random.Range(0, angle);

            _view.StopSpinAnimationAt(offset + randomOffset);
            _view.SetReward(rewardData);
            return rewardData;
        }
        
        private void OnWheelStopped(RewardData reward)
        {
            BuildWheelSlices();
        }
    }
}
