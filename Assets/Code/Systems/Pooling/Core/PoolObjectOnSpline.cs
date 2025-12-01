using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.Animations;
using Unity.Mathematics;

namespace Unity.Pool
{
    public abstract class PoolObjectOnSpline : PoolObjectBehaviour
    {
        [SerializeField] private Axis _snap;
        public SplineContainer Spline { protected get; set; }

        protected float _currentTime => _distanceTraveled / _splineLength;
        private float _distanceTraveled;
        private float _splineLength;

        public override void Enable()
        {
            base.Enable();
            _distanceTraveled = 0;
            _splineLength = Spline.CalculateLength();
        }
        protected virtual void UpdatePosition()
        {
            float3 position = Spline.EvaluatePosition(0, _currentTime);
            if (_snap.HasFlag(Axis.X)) Transform.PositionX(math.round(position.x));
            if (_snap.HasFlag(Axis.Y)) Transform.PositionY(math.round(position.y));
        }

        public void SetTime(float value)
        {
            _distanceTraveled = value * _splineLength;
            UpdatePosition();
        }
        public void SetDistance(float value)
        {
            _distanceTraveled = value;
            UpdatePosition();
        }

        public void AddDistance(float amount)
        {
            _distanceTraveled += amount;
            UpdatePosition();
        }
    }
}