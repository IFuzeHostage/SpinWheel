using System.Collections.Generic;
using System.Threading.Tasks;
using IFuzeHostage.SpinWheel.Data;

namespace IFuzeHostage.SpinWheel
{
    internal class SpinWheelPresenter : ISpinWheelPresenter
    {
        private SpinWheelView _view;
        private ISpinWheelController _controller;

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
            
        }

        public void OnClose()
        {
            
        }

        public void SpinClicked()
        {
            _view.StartSpin();
            WaitForReward();
        }
        
        private void OnControllerInitialized()
        {
            BuildWheelSlices();
        }

        private async void BuildWheelSlices()
        {
            List<RewardData> rewardDatas = await _controller.GetRewardList();

            for (int i = 0; i < rewardDatas.Count; i++)
            {
                RewardData reward = rewardDatas[i];
                float offset = (float) i / rewardDatas.Count * 360;
                float angle = (float) 1 / rewardDatas.Count * 360;
                
                _view.AddWheelSlice(reward, -offset, angle);
            }
        }

        private async Task<RewardData> WaitForReward()
        {
            RewardData rewardData = await _controller.GetRandomReward();
            _view.StopSpin();
            return rewardData;
        }
    }
}
