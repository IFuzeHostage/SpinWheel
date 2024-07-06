using System.Collections;
using System.Collections.Generic;
using IFuzeHostage.SpinWheel;
using UnityEngine;

public interface ISpinWheelPresenter
{
    public void Construct(ISpinWheelController controller);
    
    public void SetView(SpinWheelView view);

    public void OnOpen();
    public void OnClose();

    public void SpinClicked();
}
