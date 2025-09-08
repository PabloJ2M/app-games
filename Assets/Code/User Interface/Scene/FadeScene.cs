using System;
using UnityEngine.Animations;

namespace UnityEngine.SceneManagement
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeScene : TweenAlpha
    {
        private CanvasGroup _canvasGroup;
        public Action<bool> onComplete;

        protected override void Awake() { base.Awake(); _canvasGroup = GetComponent<CanvasGroup>(); }

        private void Start()
        {
            _tweenCore.IsEnabled = onComplete == null;
            _canvasGroup.alpha = _alpha = GetCurve(_tweenCore.IsEnabled ? 1f : 0f);
            if (_tweenCore.IsEnabled) FadeOut(); else FadeIn();
        }
        protected override void OnUpdate(float value) { base.OnUpdate(value); _canvasGroup.alpha = value; }
        protected override void OnComplete()
        {
            base.OnComplete();
            onComplete?.Invoke(true);
            if (!_tweenCore.IsEnabled) Destroy(gameObject);
        }
    }
}