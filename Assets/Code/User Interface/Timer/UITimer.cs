using UnityEngine.Events;

namespace UnityEngine.UI
{
    public class UITimer : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField, Range(0, 1)] private float _speed;
        [SerializeField, Space] private UnityEvent _onTimeout;

        public float SpeedMultiply { private get; set; } = 1f;

        private GameManager _manager;
        private bool _isCompleted;

        private void Awake() => _manager = GameManager.Instance;
        private void Update()
        {
            if (!_manager.IsEnabled) return;

            if (_image.fillAmount > 0)
                _image.fillAmount -= _speed * SpeedMultiply * Time.deltaTime;

            if (_isCompleted || _image.fillAmount > 0) return;
            _isCompleted = true;
            _onTimeout.Invoke();
        }

        public void AddTime(float percent) => _image.fillAmount += percent;
        public void ResetTime() => _image.fillAmount = 1f;
    }
}