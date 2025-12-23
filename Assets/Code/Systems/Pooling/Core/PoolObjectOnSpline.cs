using System.Collections;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.Animations;
using Unity.Mathematics;

namespace Unity.Pool
{
    public abstract class PoolObjectOnSpline : PoolObjectBehaviour
    {
        [Header("Position Handler")]
        [SerializeField] private Axis _snap;
        [SerializeField] private bool _roundPosition;

        public SplineContainer Spline { protected get; set; }

        protected float _currentTime, _splineLength;

        public override void Enable()
        {
            base.Enable();
            _currentTime = 0;
            _splineLength = Spline.CalculateLength();
        }
        protected virtual void UpdatePosition()
        {
            float3 position = Spline.EvaluatePosition(_currentTime);
            if (_snap.HasFlag(Axis.X)) Transform.PositionX(_roundPosition ? math.round(position.x) : position.x);
            if (_snap.HasFlag(Axis.Y)) Transform.PositionY(_roundPosition ? math.round(position.y) : position.y);

            if (_currentTime >= 1f) StartCoroutine(Release());
        }

        private IEnumerator Release()
        {
            yield return null;
            Destroy();
        }

        public void SetTime(float value)
        {
            _currentTime = value;
            UpdatePosition();
        }
        public void SetDistance(float value)
        {
            _currentTime = value / _splineLength;
            UpdatePosition();
        }

        public virtual void AddTime(float amount)
        {
            _currentTime += amount;
            UpdatePosition();
        }
        public virtual void AddDistance(float amount)
        {
            _currentTime += amount / _splineLength;
            UpdatePosition();
        }
    }
}