using PrimeTween;

namespace UnityEngine.Animations
{
    public abstract class TweenCustom : TweenBehaviour<float>
    {
        protected float _current;

        protected override void OnStart() => _current = _tweenCore.IsEnabled ? 1f : 0f;
        protected virtual void OnUpdate(float value) => _current = value;

        protected override void OnPlay(bool value)
        {
            base.OnPlay(value);

            _tweenSettings = new(_current, value ? 1f : 0f, _settings);
            Tween tween = Tween.Custom(_tweenSettings, OnUpdate);
            tween.OnComplete(OnComplete);
        }
    }
}