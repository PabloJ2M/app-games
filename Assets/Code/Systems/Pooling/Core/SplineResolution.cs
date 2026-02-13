using UnityEngine;
using UnityEngine.Splines;

namespace Unity.Pool
{
    using Mathematics;

    [RequireComponent(typeof(SplineContainer))]
    public class SplineResolution : MonoBehaviour, ISpline
    {
        [Tooltip("number of points in spline")]
        [SerializeField, Range(2, byte.MaxValue)] private byte _resolution = 2;

        private float3[] _points;
        private float _length, _lengthInv;

        public float LengthInv => _lengthInv;
        public float Length => _length;

        private void Awake()
        {
            var spline = GetComponent<SplineContainer>();

            _points = new float3[_resolution];
            _length = spline.CalculateLength();
            _lengthInv = 1f / _length;

            for (int i = 0; i < _resolution; i++)
            {
                float t = i / (float)(_resolution - 1);
                _points[i] = spline.EvaluatePosition(t);
            }
        }

        public float3 GetPosition(float t)
        {
            float f = math.clamp(t, 0f, 1f) * (_resolution - 1);
            int a = (int)math.floor(f);
            int b = math.min(a + 1, _resolution - 1);

            float lerp = f - a;
            return math.lerp(_points[a], _points[b], lerp);
        }
    }
}