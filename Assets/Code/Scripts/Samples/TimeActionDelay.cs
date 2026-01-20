using System.Collections;

namespace UnityEngine.Events
{
    public class TimeActionDelay : MonoBehaviour
    {
        [SerializeField] private float _time = 1f;
        [SerializeField] private bool _playOnAwake = false;
        [SerializeField] private bool _disableOnComplete = false;

        [SerializeField] private UnityEvent _onCompleted;
        private WaitForSeconds _delay;

        private void Awake() => _delay = new(_time);
        private void OnEnable() { if (_playOnAwake) Play(); }
        private void OnDisable() => Cancel();

        private IEnumerator DelayAction()
        {
            yield return _delay;
            _onCompleted.Invoke();

            if (_disableOnComplete)
                gameObject.SetActive(false);
        }

        public void Play() => StartCoroutine(DelayAction());
        public void Cancel() => StopAllCoroutines();
    }
}