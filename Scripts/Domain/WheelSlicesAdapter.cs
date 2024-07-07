using System.Collections.Generic;
using System.Linq;
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
            var pooledSlice = _slices.FirstOrDefault(slice => !slice.gameObject.activeSelf);
            if (pooledSlice != null)
            {
                pooledSlice.gameObject.SetActive(true);
                pooledSlice.Set(rewardData, selfAngle);
                pooledSlice.RectTransform.localRotation = Quaternion.Euler(0,0,startAngle);
                return;
            }
            
            SpinWheelSlice slice = GameObject.Instantiate(_spinWheelSlice, _sliceParent);
            
            slice.Set(rewardData, selfAngle);
            slice.RectTransform.localRotation = Quaternion.Euler(0,0,startAngle);
            
            _slices.Add(slice);
        }

        public void ClearSlices()
        {
            foreach (var slice in _slices)
            {
                slice.gameObject.SetActive(false);
            }
        }
    }
}