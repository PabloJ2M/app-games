namespace UnityEngine.Animations
{
    public class TweenRotate : TweenTransform
    {
        [SerializeField] protected Axis _axis;
        [SerializeField] protected float _angle;

        protected virtual void Start()
        {
            _from = _to = _transform.eulerAngles;
            _to += _axis.Get() * _angle;
        }

        protected override void OnPerformePlay(bool value)
        {
            CancelTween();

            //create tween animation
            LTDescr tween = LeanTween.rotateAround(_self, _axis.Get(), value ? _angle : -_angle, _tweenCore.Time).setEase(_animationCurve);
            if (_tweenCore.IgnoreTimeScale) tween.setIgnoreTimeScale(true);
            if (_tweenCore.Delay != 0) tween.setDelay(_tweenCore.Delay);
            if (_tweenCore.IsLoop) tween.setLoopPingPong(-1);
            tween.setOnUpdateVector3(OnUpdate);
            tween.setOnComplete(OnComplete);

            //saved tween ID
            _tweenID = tween.uniqueId;
        }
    }
}