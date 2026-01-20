namespace UnityEngine.Animations
{
    [RequireComponent(typeof(CanvasGroup))]
    public class TweenCanvasGroup : TweenCustom
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
        protected override void OnComplete()
        {
            base.OnComplete();

            if (_disableOnHide && _current == 0)
                gameObject.SetActive(false);
        }
        protected override void OnPlay(bool value)
        {
            base.OnPlay(value);
            PerformceInteraction(value);
        }
        protected override void OnUpdate(float value)
        {
            base.OnUpdate(value);
            _canvasGroup.alpha = value;
        }

        private void PerformceInteraction(bool value)
        {
            if (_modifyInteraction)
                _canvasGroup.interactable = _canvasGroup.blocksRaycasts = value;
        }

        public void FadeIn() => _tweenCore?.Play(true);
        public void FadeOut() => _tweenCore?.Play(false);
    }
}