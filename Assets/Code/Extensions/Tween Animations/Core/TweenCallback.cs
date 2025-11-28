using UnityEngine.Events;

namespace UnityEngine.Animations
{
    public class TweenCallback : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onCompleteAnimation;

        private TweenCore _core;

        private void Awake() => _core = GetComponent<TweenCore>();
        private void Start() => _core.onComplete += _onCompleteAnimation.Invoke;
        private void OnDestroy() => _core.onComplete -= _onCompleteAnimation.Invoke;
    }
}