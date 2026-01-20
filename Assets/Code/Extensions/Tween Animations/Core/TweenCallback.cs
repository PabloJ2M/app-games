using UnityEngine.Events;

namespace UnityEngine.Animations
{
    [RequireComponent(typeof(ITweenCallback))]
    public class TweenCallback : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onCompleteAnimation;
        private ITweenCallback _tween;

        private void Awake()
        {
            _tween = GetComponent<ITweenCallback>();
            _tween.onCompleted += _onCompleteAnimation.Invoke;
        }
        private void OnDestroy()
        {
            _tween.onCompleted -= _onCompleteAnimation.Invoke;
        }
    }
}