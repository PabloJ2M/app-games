using System.Collections;

namespace UnityEngine.Video
{
    using Events;

    [RequireComponent(typeof(VideoPlayer))]
    public class VideoEventHandler : MonoBehaviour
    {
        [SerializeField, Range(0f, 1f)] private float _percent = 1f;
        [SerializeField] private UnityEvent _onStart, _onComplete;

        private VideoPlayer _player;
        private WaitWhile _loading;

        private void Awake() => _player = GetComponent<VideoPlayer>();
        private void Start() => _loading = new(() => !_player.isPrepared);

        public void Play()
        {
            _player.Prepare();
            StartCoroutine(OnStart());
        }
        public void Play(VideoClip clip)
        {
            _player.clip = clip;
            Play();
        }

        private IEnumerator OnStart()
        {
            yield return _loading;

            _onStart.Invoke();
            _player.Play();

            StartCoroutine(OnComplete());
        }
        private IEnumerator OnComplete()
        {
            yield return new WaitForSecondsRealtime((float)_player.length * _percent);
            _onComplete.Invoke();
        }
    }
}