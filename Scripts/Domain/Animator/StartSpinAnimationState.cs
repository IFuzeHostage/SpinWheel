using IFuzeHostage.SpinWheel.Presentation.SpinWheel;
using UnityEngine;

namespace IFuzeHostage.SpinWheel.Domain.Animator
{
    internal class StartSpinAnimationState : SpinAnimationState
    {
        private readonly float _maxSpeed;
        private readonly float _acceleration;
        
        public StartSpinAnimationState(BaseSpinWheelAnimator animator, float maxSpeed, float acceleration) : base(animator)
        {
            _maxSpeed = maxSpeed;
            _acceleration = acceleration;
        }
        
        public override void Enter()
        {
            
        }

        public override void Update()
        {
            Animator.CurrentSpeed = Mathf.MoveTowards(Animator.CurrentSpeed, _maxSpeed, _acceleration);

            if (Animator.CurrentSpeed >= _maxSpeed)
                OnComplete?.Invoke();
        }
    }
}