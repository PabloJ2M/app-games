namespace UnityEngine.Audio
{
    public abstract class AudioEmitterBehaviour : MonoBehaviour
    {
        [Tooltip("Override Audio Source Manager, Default = Null")]
        [SerializeField] protected AudioSource _overrideSource = null;
        
        [Space]

        [SerializeField] protected ChannelType _type = ChannelType.SoundFx;
        [SerializeField] protected bool _preloadOnStart;

        protected IAudioManager _manager;

        protected virtual void Awake() => _manager = AudioManager.Instance;

        public abstract void Play();
        public abstract void PlayOneShot();
        public void PlayDefault() => _manager?.PlayDefault(_type);
    }
}