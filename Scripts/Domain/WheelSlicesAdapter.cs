using System.Collections.Generic;
using IFuzeHostage.SpinWheel.Data;
using UnityEngine;

namespace IFuzeHostage.SpinWheel
{
    public class WheelSlicesAdapter
    {
        private readonly SpinWheelSlice _spinWheelSlice;
        private readonly RectTransform _sliceParent;

        private List<SpinWheelSlice> _slices = new();
        
        public WheelSlicesAdapter(SpinWheelSlice slicePrefab, RectTransform sliceParent)
        {
            _spinWheelSlice = slicePrefab;
            _sliceParent = sliceParent;
        }
        
        public void AddWheelSlice(RewardData rewardData, float startAngle, float selfAngle)
        {
            SpinWheelSlice slice = GameObject.Instantiate(_spinWheelSlice, _sliceParent);
            
            slice.Set(rewardData, selfAngle);
            slice.RectTransform.rotation = Quaternion.Euler(0,0,startAngle);
            
            _slices.Add(slice);
        }
    }
}