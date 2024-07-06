namespace IFuzeHostage.SpinWheel
{
    internal class SpinWheelPresenter : ISpinWheelPresenter
    {
        private SpinWheelView _view;
        private ISpinWheelController _controller;

        public void Construct(ISpinWheelController controller)
        {
            _controller = controller;
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
            
        }
    }
}