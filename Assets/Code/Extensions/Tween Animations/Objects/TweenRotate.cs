using Unity.Mathematics;

namespace UnityEngine.Animations
{
    public class TweenRotate : TweenCustomVector
    {
        [SerializeField] protected Axis _axis;
        [SerializeField] protected AnimationCurve _curve;
        [SerializeField] protected float _angle;

        protected override void Awake()
        {
            base.Awake();
            _from = _to = _transform.localEulerAngles;
            _to += _axis.Get() * _angle;

            _transform.eulerAngles = _tweenCore.IsEnabled ? _from : _to;
        }
        protected override void OnUpdate(float value)
        {
            base.OnUpdate(value);

            float time = _curve.Evaluate(value);
            _transform.localEulerAngles = math.lerp(_from, _to, time);
        }

        [ContextMenu("FlipIn")] public void RotateIn() => _tweenCore?.Play(true);
        [ContextMenu("FlipOut")] public void RotateOut() => _tweenCore?.Play(false);
    }
}