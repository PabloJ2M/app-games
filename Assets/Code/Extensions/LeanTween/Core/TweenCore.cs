using System;
using System.Threading.Tasks;

namespace UnityEngine.Animations
{
    public interface ITween
    {
        public void Play(bool value);
    }

    public class TweenCore : MonoBehaviour, ITween
    {
        [SerializeField] private TweenGroup _group;

        [SerializeField, Range(0, 1)] private float _time;
        [SerializeField, Range(0, 1)] private float _delay;
        [SerializeField] private bool _startDisable, _playOnAwake, _isLoop, _ignoreTimeScale;

        public event Action<bool> onPlayStatusChanged;

        public float Time => _time;
        public float Delay => _delay;
        public bool IsLoop => _isLoop;
        public bool IgnoreTimeScale => _ignoreTimeScale;

        public bool IsEnabled { get; set; }

        private void Awake() => IsEnabled = !_startDisable;
        private void OnEnable() => _group?.AddListener(this);
        private void OnDisable() => _group?.RemoveListener(this);

        private async void Start() { await Task.Yield(); if (_playOnAwake) Play(!IsEnabled); }
        public void Play(bool value) { onPlayStatusChanged?.Invoke(value); IsEnabled = value; }

        [ContextMenu("Swap Animation")] public void SwapTweenAnimation() => Play(!IsEnabled);
    }
}