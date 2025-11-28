namespace UnityEngine.Animations
{
    [RequireComponent(typeof(CanvasGroup))]
    public class TweenCanvasGroup : TweenAlpha
    {
        [SerializeField] private bool _disableOnHide;
        [SerializeField] private bool _modifyInteraction;
        private CanvasGroup _canvasGroup;

        protected override void Awake()
        {
            base.Awake();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        protected override void OnStart()
        {
            PerformceInteraction(_tweenCore.IsEnabled);
            OnUpdate(_tweenCore.IsEnabled ? 1f : 0f);
        }
        protected override void OnUpdate(float value)
        {
            base.OnUpdate(value);
            if (_canvasGroup) _canvasGroup.alpha = value;
        }
        protected override void OnComplete()
        {
            base.OnComplete();
            _tweenCore.onComplete?.Invoke();
            if (_disableOnHide && _alpha == 0) gameObject.SetActive(false);
        }
        protected override void OnPerformePlay(bool value)
        {
            base.OnPerformePlay(value);
            if (_tweenCore.IsEnabled != value)
                PerformceInteraction(value);
        }

        private void PerformceInteraction(bool value)
        {
            if (_modifyInteraction && _canvasGroup)
                _canvasGroup.interactable = _canvasGroup.blocksRaycasts = value;
        }
    }
}