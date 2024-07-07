using IFuzeHostage.SpinWheel.Presentation.SpinWheel;
using IFuzeHostage.SpinWheel.Utilities;
using UnityEngine;

namespace IFuzeHostage.SpinWheel.Domain.Animator
{
    internal class StoppingAtSpinAnimatorState: SpinAnimationState
    {
        public float TargetRotation
        {
            get => _targetRotation;
            set => _targetRotation = value;
        }

        private readonly float _maxSpeed;
        private readonly int _fakeRotations;
        
        private float _remainingRotation;
        private float _totalRotationToDo;

        private float _targetRotation;
        
        public StoppingAtSpinAnimatorState(BaseSpinWheelAnimator animator, float maxSpeed, int fakeRotations) : base(animator)
        {
            _maxSpeed = maxSpeed;
            _fakeRotations = fakeRotations;
        }
        
        public override void Enter()
        {
            _totalRotationToDo = _targetRotation + _fakeRotations - Animator.CurrentRotation % 1;
            _remainingRotation = _totalRotationToDo;
        }

        public override void Update()
        {
            if (_remainingRotation <= CircleUtilities.APPROXIMATE_THRESHOLD)
            {
                Animator.CurrentSpeed = 0;
                OnComplete?.Invoke();
                return;
            }

            var progress = 1 - (_remainingRotation / _totalRotationToDo);

            var newSpeed = Mathf.Lerp(_maxSpeed, 0, progress);
            
            Animator.CurrentSpeed = newSpeed;

            _remainingRotation -= newSpeed * Time.deltaTime;
        }
    }
}