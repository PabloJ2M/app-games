namespace UnityEngine.Animations
{
    [RequireComponent(typeof(CanvasGroup))]
    public class TweenCanvasGroup : TweenAlpha
    {
        [SerializeField] private bool _modifyInteraction;

        private CanvasGroup _canvasGroup;

        protected override void Awake()
        {
            base.Awake();
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        private void Start()
        {
            _alpha = _canvasGroup.alpha = _tweenCore.IsEnabled ? 1f : 0f;
            PerformceInteraction(_tweenCore.IsEnabled);
        }
        private void PerformceInteraction(bool value)
        {
            if (_modifyInteraction)
                _canvasGroup.interactable = _canvasGroup.blocksRaycasts = value;
        }
        
        protected override void OnUpdate(float value) { base.OnUpdate(value); _canvasGroup.alpha = value; }
        protected override void OnPerformePlay(bool value)
        {
            base.OnPerformePlay(value);
            if (_tweenCore.IsEnabled != value)
                PerformceInteraction(value);
        }
        protected override void OnComplete()
        {
            base.OnComplete();
            _canvasGroup.alpha = _alpha;
        }
    }
}