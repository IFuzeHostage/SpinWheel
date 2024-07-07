using IFuzeHostage.SpinWheel;

namespace IFuzeHostage.SpinWheel.Presentation.SpinWheel
{
    internal interface ISpinWheelPresenter
    {
        public void Construct(ISpinWheelController controller);
        
        public void SetView(SpinWheelView view);

        public void OnOpen();
        public void OnClose();

        public void SpinStarted();
    }
}
