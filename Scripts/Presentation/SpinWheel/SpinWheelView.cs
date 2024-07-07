using System;
using IFuzeHostage.SpinWheel;
using IFuzeHostage.SpinWheel.Data;
using IFuzeHostage.SpinWheel.Domain;
using UnityEngine;

namespace IFuzeHostage.SpinWheel.Presentation.SpinWheel
{
    public class SpinWheelView : MonoBehaviour
    {
        public Action<RewardData> OnWheelStopped;

        [SerializeField]
        private SpinWheelSlice _slicePrefab;

        [SerializeField]
        private SpinWheelAnimator _animator;

        [SerializeField]
        private RectTransform _sliceParent;

        private RewardData _currentReward;

        private ISpinWheelPresenter _presenter;
        private WheelSlicesAdapter _sliceAdapter;

        public void ClearWheelSlices()
        {
            _sliceAdapter.ClearSlices();
        }

        public void AddWheelSlice(RewardData rewardData, float startAngle, float selfAngle)
        {
            _sliceAdapter.AddWheelSlice(rewardData, startAngle, selfAngle);
        }

        public void Open(SpinWheelRewardsData rewardDatas)
        {
            _presenter.Construct(new RandomSpinWheelController(rewardDatas));
        }

        public void Open(ISpinWheelController customWheelController)
        {
            _presenter.Construct(customWheelController);
        }

        public void StartSpin()
        {
            _presenter.SpinStarted();
        }

        public void StartSpinAnimation()
        {
            _animator.StartSpin();
        }

        public void StopSpinAnimation()
        {
            _animator.StopSpin();
        }

        public void SetReward(RewardData currentReward)
        {
            _currentReward = currentReward;
        }

        public void StopSpinAnimationAt(float angle)
        {
            _animator.StopSpinAt(angle);
        }

        private void OnAnimationStopped()
        {
            OnWheelStopped?.Invoke(_currentReward);
        }

        private void Awake()
        {
            _presenter = new SpinWheelPresenter();
            _presenter.SetView(this);

            _sliceAdapter = new WheelSlicesAdapter(_slicePrefab, _sliceParent);

            _animator.OnSpinFinished.AddListener(OnAnimationStopped);
        }

        private void OnEnable()
        {
            _presenter.OnOpen();
        }

        private void OnDisable()
        {
            _presenter.OnClose();
        }
    }
}