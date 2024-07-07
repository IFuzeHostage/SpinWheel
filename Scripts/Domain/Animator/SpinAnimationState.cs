using System;

namespace IFuzeHostage.SpinWheel
{
    internal abstract class SpinAnimationState
    {
        public Action OnComplete;
        
        protected readonly BaseSpinWheelAnimator Animator;

        public SpinAnimationState(BaseSpinWheelAnimator animator)
        {
            Animator = animator;
        }

        public abstract void Enter();

        public abstract void Update();
    }
}