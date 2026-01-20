using Unity.Mathematics;
using PrimeTween;

namespace UnityEngine.Animations
{
    public class TweenPosition : TweenTransform
    {
        [SerializeField] protected Direction _direction;
        [SerializeField] protected float2 _distance;

        protected override void Awake()
        {
            base.Awake();
            _from = _to = _transform.localPosition;
            _to += _direction.Get();
        }
        protected override void OnPlay(bool value)
        {
            if (_tweenCore.IsEnabled == value) return;

            _tweenSettings = new(_transform.localPosition, value ? _from : _to, _settings);
            _tween = Tween.LocalPosition(_transform, _tweenSettings);
            _tween.OnComplete(OnComplete);
        }
    }
}