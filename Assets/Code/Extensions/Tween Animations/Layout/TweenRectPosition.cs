using Unity.Mathematics;
using PrimeTween;

namespace UnityEngine.Animations
{
    public class TweenRectPosition : TweenRectTransform
    {
        [SerializeField] protected Direction _direction;
        [SerializeField] protected float2 _overrideDistance;

        protected override void Awake()
        {
            base.Awake();

            float2 size = _transform.rect.size;
            float3 direction = _direction.Get();

            if (_overrideDistance.x != 0) size.x = _overrideDistance.x;
            if (_overrideDistance.y != 0) size.y = _overrideDistance.y;

            _from = _to = _transform.localPosition;
            _to += new float3(direction.x * size.x, direction.y * size.y, 0f);
        }

        protected override void OnPlay(bool value)
        {
            base.OnPlay(value);

            _tweenSettings = new(_transform.localPosition, value ? _from : _to, _settings);
            _tween = Tween.LocalPosition(_transform, _tweenSettings);
            _tween.OnComplete(OnComplete);
        }
    }
}