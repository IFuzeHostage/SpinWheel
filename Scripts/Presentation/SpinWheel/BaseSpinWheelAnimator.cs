using System;
using Unity.Mathematics;
using UnityEngine;

namespace IFuzeHostage.SpinWheel
{
    public class BaseSpinWheelAnimator : SpinWheelAnimator
    {
        [SerializeField]
        private RectTransform _wheelRect;
        [SerializeField]
        private float _acceleration = 1;
        [SerializeField]
        private float _deceleration = 1;
        [SerializeField]
        private float _maxSpeed = 5f;
        [SerializeField]
        private float _minSpinTime = 3f;
        
        private float _currentRotation;

        private float _targetSpeed;
        private float _currentSpeed;

        private bool _isSpinning;

        private float _spinStartTime = float.MinValue;
        
        public override void StartSpin()
        {
            _spinStartTime = Time.time;
            _isSpinning = true;
        }

        public override void StopSpin()
        {
            _isSpinning = false;
        }

        public override void StopSpinAt(float angle)
        {
            
        }


        private void UpdateSpeed()
        {
            var delta = (_targetSpeed > _currentSpeed ? _acceleration : _deceleration) * Time.deltaTime;
            _currentSpeed = Mathf.MoveTowards(_currentSpeed, _targetSpeed, delta);
        }

        private void UpdateRotation()
        {
            _currentRotation += _currentSpeed * Time.deltaTime * 360f;
            _wheelRect.rotation = quaternion.Euler(0f,0f,_currentRotation);
        }

        private bool IsMinSpinDone()
        {
            return (Time.time - _spinStartTime) > _minSpinTime;
        }

        private void LateUpdate()
        {
            _targetSpeed = (_isSpinning || !IsMinSpinDone()) ? _maxSpeed : 0f;
            
            UpdateSpeed();
            UpdateRotation();
        }
    }
}