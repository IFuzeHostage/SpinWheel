using System.Collections;
using System.Collections.Generic;
using IFuzeHostage.SpinWheel;
using IFuzeHostage.SpinWheel.Data;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheelSlice : MonoBehaviour
{
    public RectTransform RectTransform
    {
        get
        {
            if (_rect == null)
                _rect = GetComponent<RectTransform>();

            return _rect;
        }
    }
    
    [SerializeField]
    private Image _sliceImage;
    [SerializeField]
    private Image _innerSliceImage;
    [SerializeField]
    private RewardDisplay _rewardDisplay;
    [SerializeField]
    private float _innerSliceOffset = 1;

    private RectTransform _rect;

    private RectTransform _innerSliceRect;
    
    public void Set(RewardData data, float sliceSize)
    {
        _rewardDisplay.SetData(data);
        _rewardDisplay.RectTransform.rotation = Quaternion.Euler(0f,0f, -sliceSize / 2);
        
        _sliceImage.fillAmount = sliceSize / 360f;
        
        _innerSliceRect.rotation = Quaternion.Euler(0f, 0f, -_innerSliceOffset);
        _innerSliceImage.fillAmount = (sliceSize - _innerSliceOffset) / 360f;
    }

    private void Awake()
    {
        _innerSliceRect = _innerSliceImage.GetComponent<RectTransform>();
    }
}
