namespace UnityEngine.Animations
{
    public class TweenPosition : TweenTransform
    {
        [SerializeField] protected Direction _direction;
        [SerializeField] protected Vector2 _overrideDistance;

        protected virtual void Start()
        {
            Vector3 size = _transform.rect.size;
            Vector3 direction = _direction.Get();
            if (_overrideDistance.x != 0) size.x = _overrideDistance.x;
            if (_overrideDistance.y != 0) size.y = _overrideDistance.y;

            _from = _to = _transform.localPosition;
            _to += new Vector3(direction.x * size.x, direction.y * size.y, 0f);
        }

        protected override void OnPerformePlay(bool value)
        {
            if (_tweenCore.IsEnabled == value) return;
            CancelTween();

            //create tween animation
            LTDescr tween = LeanTween.moveLocal(_self, value ? _from : _to, _tweenCore.Time).setEase(_animationCurve);
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