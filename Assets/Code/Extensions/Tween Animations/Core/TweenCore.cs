using System;
using System.Threading.Tasks;
using PrimeTween;

namespace UnityEngine.Animations
{
    public interface ITween
    {
        public void Play(bool value);
    }

    [DefaultExecutionOrder(100)]
    public class TweenCore : MonoBehaviour, ITween
    {
        [SerializeField] private TweenGroup _group;
        [SerializeField] private TweenSettings _settings;
        [SerializeField] private bool _startDisable, _playOnAwake;

        public bool IsEnabled { get; set; }
        public TweenSettings Settings => _settings;

        public event Action<bool> onPlayStatusChanged;
        public event Action onCancel;
        public Action onComplete;

        private async void OnEnable()
        {
            IsEnabled = !_startDisable;
            _group?.AddListener(this);

            await Task.Yield();
            if (_playOnAwake) Play(!IsEnabled);
        }
        private void OnDisable()
        {
            onCancel?.Invoke();
            _group?.RemoveListener(this);
        }

        public void Play(bool value)
        {
            if (value == IsEnabled) return;
            onPlayStatusChanged?.Invoke(value);
            IsEnabled = value;
        }

        [ContextMenu("Swap Animation")] public void SwapTweenAnimation() => Play(!IsEnabled);
    }
}