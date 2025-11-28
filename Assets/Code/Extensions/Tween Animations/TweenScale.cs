using PrimeTween;

namespace UnityEngine.Animations
{
    public class TweenScale : TweenTransform
    {
        [SerializeField, Range(0.5f, 1.5f)] private float _scaleFactor = 1f;

        protected override void Awake()
        {
            base.Awake();
            _from = _to = _transform.localScale;
            _to *= _scaleFactor;
        }

        protected override void OnStart() { }
        protected override void OnComplete() { }
        protected override void OnPerformePlay(bool value)
        {
            //if (_tweenCore.IsEnabled == value) return;
            if (_tween.isAlive) CancelTween();

            _tween = Tween.Scale(_transform, !value ? _to : _from, !value ? _from : _to, _settings);
            //tween.OnComplete(OnComplete);
        }
    }
}