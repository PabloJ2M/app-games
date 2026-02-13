using UnityEngine;
using UnityEngine.Animations;

namespace Unity.Pool
{
    using Mathematics;

    public class PoolObjectOnSpline : PoolObjectBehaviour
    {
        [Header("Position Handler")]
        [SerializeField] private Axis _followAxis;
        [SerializeField] private bool _roundPosition;

        public ISpline Spline { protected get; set; }
        protected float _currentTime;

        public override void Enable()
        {
            base.Enable();
            _currentTime = 0;
        }
        protected virtual void UpdatePosition()
        {
            if (_currentTime >= 1f) {
                Destroy();
                return;
            }

            float3 position = Spline.GetPosition(_currentTime);
            if ((_followAxis & Axis.X) != 0) Transform.PositionX(_roundPosition ? math.round(position.x) : position.x);
            if ((_followAxis & Axis.Y) != 0) Transform.PositionY(_roundPosition ? math.round(position.y) : position.y);
        }

        public void SetTime(float value)
        {
            _currentTime = value;
            UpdatePosition();
        }
        public void SetDistance(float value)
        {
            _currentTime = value * Spline.LengthInv;
            UpdatePosition();
        }

        public virtual void AddTime(float amount)
        {
            _currentTime += amount;
            UpdatePosition();
        }
        public virtual void AddDistance(float amount)
        {
            _currentTime += amount * Spline.LengthInv;
            UpdatePosition();
        }

        public void SnapPosition()
        {
            float distance = _currentTime * Spline.Length;
            float snapped = Mathf.Round(distance / 1.5f) * 1.5f;
            SetDistance(snapped);
        }
    }
}