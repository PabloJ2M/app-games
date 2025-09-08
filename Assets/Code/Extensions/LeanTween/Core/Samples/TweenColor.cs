namespace UnityEngine.Animations
{
    public abstract class TweenColor : TweenBehaviour<Color>
    {
        protected Color _default = Color.white;
        protected Color _target = Color.white;

        protected override void OnUpdate(Color value) { }
        protected override void OnPerformePlay(bool value)
        {
            CancelTween();

            //create tween animation
            LTDescr tween = LeanTween.value(_self, _default, _target, _tweenCore.Time).setEase(_animationCurve);
            if (_tweenCore.IgnoreTimeScale) tween.setIgnoreTimeScale(true);
            if (_tweenCore.Delay != 0) tween.setDelay(_tweenCore.Delay);
            if (_tweenCore.IsLoop) tween.setLoopPingPong(-1);
            tween.setOnComplete(OnComplete);
            tween.setOnUpdate(OnUpdate);

            //saved tween ID
            _tweenID = tween.uniqueId;
        }
    }
}