using IFuzeHostage.SpinWheel.Domain.Animator;
using IFuzeHostage.SpinWheel.Utilities;
using UnityEngine;

namespace IFuzeHostage.SpinWheel.Presentation.SpinWheel
{
    public class BaseSpinWheelAnimator : SpinWheelAnimator
    {
        public float CurrentRotation
        {
            get => _currentRotation;

            private set
            {
                _currentRotation = value;
                _wheelRect.rotation = Quaternion.Euler(0, 0, _currentRotation * CircleUtilities.CIRCLE_DEGREES);
            }
        }

        public float CurrentSpeed
        {
            get => _currentSpeed;
            set => _currentSpeed = value;
        }
        
        [SerializeField,Tooltip("Rotating element of the wheel")]
        private RectTransform _wheelRect;
        
        [SerializeField,Tooltip("Acceleration of starting wheel")]
        private float _acceleration = 1;
        
        [SerializeField,Tooltip("Slowing down of stopping wheel")]
        private float _deceleration = 1;
        
        [SerializeField,Tooltip("Max rotation speed of the wheel")]
        private float _maxSpeed = 5f;
        
        [SerializeField,Tooltip("How many fake rotations while slowing down to target angle")]
        private int _fakeRotationsToTarget = 2;

        [SerializeField,Tooltip("Minimum type of spinning")]
        private float _minSpinDuration = 3f;

        private float _currentRotation;
        private float _currentSpeed;

        private SpinAnimationState _currentState;
        private StartSpinAnimationState _startState;
        private StableSpinAnimatorState _stableState;
        private StoppingAtSpinAnimatorState _stoppingAtState;
        private StoppingSpinAnimatorState _stoppingState;
        
        public override void StartSpin()
        {
            _startState.OnComplete = () => EnterState(_stableState);
            EnterState(_startState);
        }

        public override void StopSpin()
        {
            _stableState.OnComplete = () => EnterState(_stoppingState);
        }

        public override void StopSpinAt(float angle)
        {
            _stoppingAtState.TargetRotation = angle;
            _stableState.OnComplete = () => EnterState(_stoppingAtState);
        }

        private void Awake()
        {
            _startState = new StartSpinAnimationState(this, _maxSpeed, _acceleration);
            _stableState = new StableSpinAnimatorState(this, _maxSpeed, _minSpinDuration);
            _stoppingAtState = new StoppingAtSpinAnimatorState(this, _maxSpeed, _fakeRotationsToTarget);
            _stoppingState = new StoppingSpinAnimatorState(this, _deceleration);

            _stoppingAtState.OnComplete = OnAnimationStopped;
            _stoppingState.OnComplete = OnAnimationStopped;
        }
        
        private void Update()
        {
            _currentState?.Update();

            _currentRotation += _currentSpeed * Time.deltaTime;
            _wheelRect.rotation = Quaternion.Euler(0, 0, _currentRotation * CircleUtilities.CIRCLE_DEGREES);
        }

        private void OnAnimationStopped()
        {
            _currentState = null;
            OnSpinFinished?.Invoke();
        }
        
        private void EnterState(SpinAnimationState state)
        {
            _currentState = state;
            _currentState.Enter();
        }
    }
}