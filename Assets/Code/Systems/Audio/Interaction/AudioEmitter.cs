using UnityEngine.AddressableAssets;

namespace UnityEngine.Audio
{
    public class AudioEmitter : AudioEmitterBehaviour
    {
        [Header("Audio Reference")]
        [SerializeField] private AssetReferenceT<AudioClip> _audioReference;

        private async void Start()
        {
            if (_preloadOnStart)
                await _manager.LoadAudioAsset(_audioReference);
        }
        private void OnDestroy()
        {
            _manager.UnloadAudioAsset(_audioReference);
        }

        public override async void Play()
        {
            var clip = await _manager.LoadAudioAsset(_audioReference);

            if (!_overrideSource)
            {
                _manager?.Play(_type, clip);
                return;
            }

            _overrideSource.clip = clip;
            _overrideSource.Play();
        }
        public override async void PlayOneShot()
        {
            var clip = await _manager.LoadAudioAsset(_audioReference);

            if (!_overrideSource) _manager?.PlayOneShot(_type, clip);
            else _overrideSource.PlayOneShot(clip);
        }
    }
}