using PrimeTween;

namespace UnityEngine.Animations
{
    [RequireComponent(typeof(TweenCore))]
    public abstract class TweenBehaviour<T> : MonoBehaviour where T : struct
    {
        protected ITween _tweenCore;
        protected ITweenCallback _tweenCallback;

        protected Tween _tween;
        protected TweenSettings _settings => _tweenCore.Settings;
        protected TweenSettings<T> _tweenSettings;

        protected virtual void Awake()
        {
            _tweenCore = GetComponent<ITween>();
            _tweenCallback = GetComponent<ITweenCallback>();

            _tweenCallback.onPlayStatusChanged += OnPlay;
            _tweenCallback.onDisabled += OnCancel;
            _tweenCallback.onEnabled += OnStart;
        }
        protected virtual void OnDestroy()
        {
            _tweenCallback.onPlayStatusChanged -= OnPlay;
            _tweenCallback.onDisabled -= OnCancel;
            _tweenCallback.onEnabled -= OnStart;
        }

        protected virtual void OnPlay(bool value)
        {
            if (_tween.isAlive)
                OnCancel();
        }
        protected virtual void OnStart() { }
        protected virtual void OnCancel() => _tween.Stop();
        protected virtual void OnComplete() => _tweenCallback?.OnComplete();
    }
}