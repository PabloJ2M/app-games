namespace UnityEngine.Animations
{
    [RequireComponent(typeof(CanvasGroup))]
    public class TweenCanvasGroup : TweenAlpha
    {
        [SerializeField] private bool _modifyInteraction;

        private CanvasGroup _canvasGroup;

        protected override void Awake() { base.Awake(); _canvasGroup = GetComponent<CanvasGroup>(); }
        private void Start()
        {
            _alpha = _canvasGroup.alpha = _tweenCore.IsEnabled ? 1f : 0f;

            if (!_tweenCore.IsEnabled && _modifyInteraction)
                _canvasGroup.interactable = _canvasGroup.blocksRaycasts = false;
        }
        
        protected override void OnUpdate(float value) { base.OnUpdate(value); _canvasGroup.alpha = value; }
        protected override void OnComplete()
        {
            base.OnComplete();
            
            _canvasGroup.alpha = _alpha;
            if (_modifyInteraction) _canvasGroup.interactable = _canvasGroup.blocksRaycasts = _tweenCore.IsEnabled;
        }
    }
}