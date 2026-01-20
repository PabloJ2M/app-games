using Unity.Mathematics;

namespace UnityEngine.Animations
{
    public class TweenScale : TweenCustomVector
    {
        [SerializeField] protected Axis _axis = Axis.X | Axis.Y | Axis.Z;
        [SerializeField] protected AnimationCurve _curve;

        [SerializeField, Range(0f, 1f)] private float _normalFactor = 1f;
        [SerializeField, Range(0.5f, 1.5f)] private float _scaleFactor = 1f;

        protected override void Awake()
        {
            base.Awake();
            _from = (float3)_transform.localScale - _axis.Get() * (1f - _normalFactor);
            _to = _from + _axis.Get() * _scaleFactor;
            _transform.localScale = _from;
        }

        protected override void OnUpdate(float value)
        {
            base.OnUpdate(value);

            float time = _curve.Evaluate(value);
            _transform.localScale = math.lerp(_from, _to, time);
        }
    }
}