using UnityEngine;

namespace IFuzeHostage.SpinWheel
{
    internal class StoppingSpinAnimatorState : SpinAnimationState
    {
        private readonly float _deceleration;
        
        public StoppingSpinAnimatorState(BaseSpinWheelAnimator animator, float deceleartion) : base(animator)
        {
            _deceleration = deceleartion;
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