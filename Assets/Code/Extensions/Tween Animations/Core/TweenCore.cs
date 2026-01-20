using System;
using System.Threading.Tasks;
using PrimeTween;

namespace UnityEngine.Animations
{
    [DefaultExecutionOrder(100)]
    public class TweenCore : MonoBehaviour, ITween, ITweenCallback
    {
        [SerializeField] private TweenGroup _group;
        [SerializeField] private TweenSettings _settings;
        [SerializeField] private bool _startDisable, _playOnAwake;

        public TweenSettings Settings => _settings;
        public bool IsEnabled { get; set; }

        public event Action<bool> onPlayStatusChanged;
        public event Action onEnabled, onDisabled;
        public event Action onCompleted;

        private async void OnEnable()
        {
            IsEnabled = !_startDisable;
            _group?.AddListener(this);
            onEnabled?.Invoke();

            await Task.Yield();
            if (_playOnAwake) Play(!IsEnabled);
        }
        private void OnDisable()
        {
            _group?.RemoveListener(this);
            onDisabled?.Invoke();
        }

        public void Play(bool value)
        {
            if (IsEnabled == value) return;
            onPlayStatusChanged?.Invoke(value);
            IsEnabled = value;
        }
        public void ForcePlay(bool value)
        {
            IsEnabled = !value;
            Play(value);
        }

        public void OnComplete()
        {
            onCompleted?.Invoke();
        }
    }
}