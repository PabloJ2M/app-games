using System;

namespace UnityEngine.SceneManagement
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeScene : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private CanvasGroup _canvasGroup;
        private bool _isChangingScene, _completedTask;

        public Action onComplete;

        private void Awake() => _canvasGroup = GetComponent<CanvasGroup>();

        private void Start()
        {
            _isChangingScene = onComplete != null;
            _canvasGroup.alpha = _isChangingScene ? 0f : 1f;
        }
        private void Update()
        {
            float delta = Time.deltaTime * (_isChangingScene ? 1 : -1) * _speed;
            _canvasGroup.alpha += delta;

            if (_canvasGroup.alpha == 1f && !_completedTask) { onComplete?.Invoke(); _completedTask = true; }
            if (_canvasGroup.alpha == 0f) Destroy(gameObject);
        }
    }
}