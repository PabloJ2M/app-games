using UnityEngine;
using UnityEngine.Splines;

namespace Unity.Pool
{
    public abstract class PoolObjectOnSpline : PoolObjectBehaviour
    {
        public SplineContainer Spline { protected get; set; }
        public float CurrentTime { get; protected set; }

        protected virtual void UpdatePosition() => Transform.position = Spline.EvaluatePosition(CurrentTime);

        public void SetTime(float value)
        {
            CurrentTime = value;
            UpdatePosition();
        }
        public void AddTime(float amount)
        {
            CurrentTime = Mathf.Clamp01(CurrentTime + amount);
            UpdatePosition();
        }
    }
}