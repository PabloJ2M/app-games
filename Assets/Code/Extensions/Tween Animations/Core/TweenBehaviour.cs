using PrimeTween;
using System.Threading.Tasks;

namespace UnityEngine.Animations
{
    [RequireComponent(typeof(TweenCore))]
    public abstract class TweenBehaviour<T> : MonoBehaviour
    {
        protected TweenCore _tweenCore;

        protected Tween _tween;
        protected TweenSettings _settings;

        protected virtual void Awake() => _tweenCore = GetComponent<TweenCore>();
        protected virtual async void OnEnable()
        {
            _tweenCore.onPlayStatusChanged += OnPerformePlay;
            _tweenCore.onCancel += CancelTween;
            _settings = _tweenCore.Settings;

            await Task.Yield();
            OnStart();
        }
        protected virtual void OnDisable()
        {
            _tweenCore.onPlayStatusChanged -= OnPerformePlay;
            _tweenCore.onCancel -= CancelTween;
            CancelTween();
        }

        protected abstract void OnStart();
        protected abstract void OnPerformePlay(bool value);
        protected abstract void OnUpdate(T value);
        protected abstract void OnComplete();
        protected void CancelTween() => _tween.Stop();
    }
}