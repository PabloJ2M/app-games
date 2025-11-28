using PrimeTween;

namespace UnityEngine.Animations
{
    public abstract class TweenAlpha : TweenBehaviour<float>
    {
        protected float _alpha;
        
        public void FadeIn() => _tweenCore?.Play(true);
        public void FadeOut() => _tweenCore?.Play(false);

        protected override void OnUpdate(float value) => _alpha = value;
        protected override void OnComplete() => _alpha = _tweenCore.IsEnabled ? 1f : 0f;
        protected override void OnPerformePlay(bool value)
        {
            //if (_tweenCore.IsEnabled == value) return;

            Tween tween = Tween.Custom(_alpha, value ? 1f : 0f, _settings, OnUpdate);
            tween.OnComplete(OnComplete);
        }
    }
}