using UnityEngine;
using UnityEngine.Events;

namespace IFuzeHostage.SpinWheel.Presentation.SpinWheel
{
    /// <summary>
    /// Animates spinning of a SpinWheel
    /// </summary>
    public abstract class SpinWheelAnimator : MonoBehaviour
    {
        public UnityEvent OnSpinFinished;
        
        public abstract void StartSpin();
        public abstract void StopSpin();
        public abstract void StopSpinAt(float angle);
    }
}