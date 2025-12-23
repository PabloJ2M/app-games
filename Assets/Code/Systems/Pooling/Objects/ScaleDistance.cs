using Unity.Mathematics;
using UnityEngine;

namespace Unity.Pool
{
    public class ScaleDistance : PoolObjectOnSpline
    {
        [SerializeField] private AnimationCurve _curve;

        protected override void UpdatePosition()
        {
            base.UpdatePosition();
            Transform.localScale = _curve.Evaluate(_currentTime) * Vector2.one;
        }

        public override void AddTime(float amount)
        {
            float accelerate = math.max(0.01f, Transform.localScale.magnitude);
            _currentTime += accelerate * amount;
            UpdatePosition();
        }
    }
}