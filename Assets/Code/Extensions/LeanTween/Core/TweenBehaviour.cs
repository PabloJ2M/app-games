namespace UnityEngine.Animations
{
    [RequireComponent(typeof(TweenCore))]
    public abstract class TweenBehaviour<T> : MonoBehaviour
    {
        [SerializeField] protected AnimationCurve _animationCurve = new(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

        protected TweenCore _tweenCore;
        protected GameObject _self;
        protected int _tweenID = -1;

        protected virtual void Awake() { _self = gameObject; _tweenCore = GetComponent<TweenCore>(); }
        protected virtual void OnEnable() => _tweenCore.onPlayStatusChanged += OnPerformePlay;
        protected virtual void OnDisable() => _tweenCore.onPlayStatusChanged -= OnPerformePlay;
        protected float GetCurve(float time) => _animationCurve.Evaluate(time);

        protected abstract void OnPerformePlay(bool value);
        protected abstract void OnUpdate(T value);
        protected virtual void OnComplete() => _tweenID = -1;
        protected virtual void CancelTween() { if (_tweenID >= 0) LeanTween.cancel(_tweenID); }
    }
}