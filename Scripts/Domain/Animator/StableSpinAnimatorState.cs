using IFuzeHostage.SpinWheel.Presentation.SpinWheel;
using UnityEngine;

namespace IFuzeHostage.SpinWheel.Domain.Animator
{
    internal class StableSpinAnimatorState : SpinAnimationState
    {
        private readonly float _maxSpeed;
        private readonly float _minSpinDuration;

        private float _startTime;
        
        public StableSpinAnimatorState(BaseSpinWheelAnimator animator, float maxSpeed, float minSpinDuration) : base(animator)
        {
            _maxSpeed = maxSpeed;
            _minSpinDuration = minSpinDuration;
        }

        public override void Enter()
        {
            Animator.CurrentSpeed = _maxSpeed;
            _startTime = Time.time;
        }

        public override void Update()
        {
            if(Time.time - _startTime > _minSpinDuration)
                OnComplete?.Invoke();
        }
    }
}