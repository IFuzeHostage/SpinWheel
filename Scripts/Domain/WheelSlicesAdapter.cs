using UnityEngine;

namespace IFuzeHostage.SpinWheel
{
    public class WheelSlicesAdapter
    {
        private readonly SpinWheelSlice _spinWheelSlice;
        private readonly RectTransform _sliceParent; 
        
        public WheelSlicesAdapter(SpinWheelSlice slicePrefab, RectTransform sliceParent)
        {
            _spinWheelSlice = slicePrefab;
            _sliceParent = sliceParent;
        }
    }
}