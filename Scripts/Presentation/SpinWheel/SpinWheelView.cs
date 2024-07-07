using System.Collections;
using System.Collections.Generic;
using IFuzeHostage.SpinWheel;
using IFuzeHostage.SpinWheel.Data;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheelView : MonoBehaviour
{
    [SerializeField]
    private SpinWheelSlice _slicePrefab;
    [SerializeField]
    private SpinWheelAnimator _animator;
    [SerializeField]
    private RectTransform _sliceParent;
    
    private ISpinWheelPresenter _presenter;
    private WheelSlicesAdapter _sliceAdapter;

    public void AddWheelSlice(RewardData rewardData, float startAngle, float selfAngle)
    {
        _sliceAdapter.AddWheelSlice(rewardData, startAngle, selfAngle);
    }
    
    public void Open(List<RewardData> rewardDatas)
    {
        _presenter.Construct(new RandomSpinWheelController(rewardDatas));
    }

    public void Open(ISpinWheelController customWheelController)
    {
        _presenter.Construct(customWheelController);
    }
    
    public void StartSpin()
    {
        _presenter.SpinStarted();
    }
    
    public void StartSpinAnimation()
    {
        _animator.StartSpin();
    }

    public void StopSpinAnimation()
    {
        _animator.StopSpin();
    }

    public void StopSpinAnimationAt(float angle)
    {
        _animator.StopSpinAt(angle);    
    }
    
    private void Awake()
    {
        _presenter = new SpinWheelPresenter();
        _presenter.SetView(this);

        _sliceAdapter = new WheelSlicesAdapter(_slicePrefab, _sliceParent);
    }
}
