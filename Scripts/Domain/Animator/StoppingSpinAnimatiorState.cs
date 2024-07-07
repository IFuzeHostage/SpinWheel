using IFuzeHostage.SpinWheel.Presentation.SpinWheel;
using UnityEngine;

namespace IFuzeHostage.SpinWheel.Domain.Animator
{
    internal class StoppingSpinAnimatorState : SpinAnimationState
    {
        private readonly float _deceleration;
        
        public StoppingSpinAnimatorState(BaseSpinWheelAnimator animator, float deceleration) : base(animator)
        {
            _deceleration = deceleration;
        }
        
        public override void Enter()
        {
        }

        public override void Update()
        {
            var delta = _deceleration * Time.deltaTime;

            Animator.CurrentSpeed = Mathf.MoveTowards(Animator.CurrentSpeed, 0, delta);
            
            if(Animator.CurrentSpeed <= 0)
            {
                OnComplete?.Invoke();
            }
        }
    }
}