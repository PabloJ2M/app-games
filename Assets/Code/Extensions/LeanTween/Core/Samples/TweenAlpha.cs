namespace UnityEngine.Animations
{
    public abstract class TweenAlpha : TweenBehaviour<float>
    {
        protected float _alpha;
        
        public void FadeIn() => _tweenCore?.Play(true);
        public void FadeOut() => _tweenCore?.Play(false);

        protected override void OnUpdate(float value) => _alpha = value;
        protected override void OnComplete() { base.OnComplete(); _alpha = _tweenCore.IsEnabled ? 1f : 0f; }
        protected override void OnPerformePlay(bool value)
        {
            if (_tweenCore.IsEnabled == value) return;
            CancelTween();

            //create tween animation
            LTDescr tween = LeanTween.value(_self, _alpha, value ? 1f : 0f, _tweenCore.Time).setEase(_animationCurve);
            if (_tweenCore.IgnoreTimeScale) tween.setIgnoreTimeScale(true);
            if (_tweenCore.Delay != 0) tween.setDelay(_tweenCore.Delay);
            tween.setOnComplete(OnComplete);
            tween.setOnUpdate(OnUpdate);

            //saved tween ID
            _tweenID = tween.uniqueId;
        }
    }
}