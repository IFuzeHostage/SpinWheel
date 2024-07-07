using System.Collections.Generic;
using System.Threading.Tasks;
using IFuzeHostage.SpinWheel.Data;
using UnityEngine;

namespace IFuzeHostage.SpinWheel
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
            _view.OnWheelStopped += OnWheelStopped;
        }

        public void OnOpen()
        {
            
        }

        public void OnClose()
        {
            
        }

        public void SpinStarted()
        {
            WaitForReward();
        }
        
        private void OnControllerInitialized()
        {
            BuildWheelSlices();
        }

        private async void BuildWheelSlices()
        {
            _view.ClearWheelSlices();
            
            _rewardDatas = await _controller.GetRewardList();

            for (int i = 0; i < _rewardDatas.Count; i++)
            {
                RewardData reward = _rewardDatas[i];
                float offset = (float) i / _rewardDatas.Count * 360;
                float angle = (float) 1 / _rewardDatas.Count * 360;
                
                _view.AddWheelSlice(reward, -offset, angle);
            }
        }

        private async Task<RewardData> WaitForReward()
        {
            _view.StartSpinAnimation();
            RewardData rewardData = await _controller.GetRandomReward();
            
            Debug.Log(rewardData.Id);
            
            float offset = (float) _rewardDatas.IndexOf(rewardData) / _rewardDatas.Count;
            float angle = (float) 1 / _rewardDatas.Count;

            var randomOffset = Random.Range(0, angle);
            
            Debug.Log(offset);
            _view.StopSpinAnimationAt(offset - randomOffset);
            _view.SetReward(rewardData);
            return rewardData;
        }
        
        private void OnWheelStopped(RewardData reward)
        {
            BuildWheelSlices();
        }
    }
}
