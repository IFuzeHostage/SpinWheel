using System.Collections;
using System.Collections.Generic;
using IFuzeHostage.SpinWheel;
using IFuzeHostage.SpinWheel.Data;
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
    private RewardDisplay _rewardDisplay;

    private RectTransform _rect;
    
    public void Set(RewardData data, float sliceSize)
    {
        _rewardDisplay.SetData(data);
        _rewardDisplay.RectTransform.rotation = Quaternion.Euler(0f,0f, -sliceSize / 2);
        _sliceImage.fillAmount = sliceSize / 360f;
    }
}
