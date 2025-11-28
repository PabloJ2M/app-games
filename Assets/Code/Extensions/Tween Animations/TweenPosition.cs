using PrimeTween;

namespace UnityEngine.Animations
{
    public class TweenPosition : TweenTransform
    {
        [SerializeField] protected Direction _direction;
        [SerializeField] protected Vector2 _overrideDistance;

        protected override void OnStart()
        {
            Vector3 size = _transform.rect.size;
            Vector3 direction = _direction.Get();
            if (_overrideDistance.x != 0) size.x = _overrideDistance.x;
            if (_overrideDistance.y != 0) size.y = _overrideDistance.y;

            _from = _to = _transform.localPosition;
            _to += new Vector3(direction.x * size.x, direction.y * size.y, 0f);
        }
        protected override void OnComplete() => _tweenCore.onComplete?.Invoke();

        protected override void OnPerformePlay(bool value)
        {
            if (_tweenCore.IsEnabled == value) return;

            Tween tween = Tween.LocalPosition(_transform, _transform.localPosition, value ? _from : _to, _settings);
            tween.OnComplete(OnComplete);
        }
    }
}