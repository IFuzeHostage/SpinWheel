using System.Collections;
using System.Collections.Generic;
using IFuzeHostage.SpinWheel;
using IFuzeHostage.SpinWheel.Data;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheelView : MonoBehaviour
{
    [SerializeField]
    private Button _spinButton;
    [SerializeField]
    private SpinWheelSlice _slicePrefab;
    [SerializeField]
    private RectTransform _sliceParent;
    
    private ISpinWheelPresenter _presenter;
    private WheelSlicesAdapter _sliceAdapter;

    public void Open(List<RewardData> rewardDatas)
    {
        _presenter.Construct(new RandomSpinWheelController(rewardDatas));
    }

    public void Open(ISpinWheelController customWheelController)
    {
        _presenter.Construct(customWheelController);
    }
    
    private void OnSpinButton()
    {
        _presenter.SpinClicked();
    }
    
    private void Awake()
    {
        _presenter = new SpinWheelPresenter();
        _presenter.SetView(this);

        _sliceAdapter = new WheelSlicesAdapter(_slicePrefab, _sliceParent);
        
        _spinButton.onClick.AddListener(OnSpinButton);
    }
}