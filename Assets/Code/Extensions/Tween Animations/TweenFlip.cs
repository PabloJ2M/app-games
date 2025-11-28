using UnityEngine.Events;

namespace UnityEngine.Animations
{
    public class TweenFlip : TweenRotate
    {
        [SerializeField] private UnityEvent<float> _onValueChanged;

        protected override void Start() { base.Start(); if (!_tweenCore.IsEnabled) _transform.eulerAngles = _to; }
        protected override void OnPerformePlay(bool value)
        {
            if (_tweenCore.IsEnabled == value) return;
            base.OnPerformePlay(value);
        }
        protected override void OnUpdate(Vector3 value)
        {
            float time = TweenExtension.InverseLerp(_from, _to, value);
            _onValueChanged.Invoke(time);
        }

        [ContextMenu("FlipIn")] public void SwipeIn() => _tweenCore?.Play(true);
        [ContextMenu("FlipOut")] public void SwipeOut() => _tweenCore?.Play(false);
        [ContextMenu("Swap Animation")] public void SwapAnimation() => _tweenCore?.SwapTweenAnimation();
    }
}