using UnityEngine.AddressableAssets;

namespace UnityEngine.Audio
{
    public class AudioEmitterRandom : AudioEmitterBehaviour
    {
        [Header("Audio Reference")]
        [SerializeField] private AssetReferenceT<AudioClip>[] _audioReference = new AssetReferenceT<AudioClip>[1];
        private int _randomIndex => Random.Range(0, _audioReference.Length);

        private async void Start()
        {
            if (!_preloadOnStart) return;

            foreach (var asset in _audioReference)
                await _manager.LoadAudioAsset(asset);
        }
        private void OnValidate()
        {
            if (_audioReference.Length == 0)
                _audioReference = new AssetReferenceT<AudioClip>[1];
        }
        private void OnDestroy()
        {
            foreach (var asset in _audioReference)
                _manager.UnloadAudioAsset(asset);
        }

        public override async void Play()
        {
            var clip = await _manager.LoadAudioAsset(_audioReference[_randomIndex]);

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
            var clip = await _manager.LoadAudioAsset(_audioReference[_randomIndex]);

            if (!_overrideSource) _manager?.PlayOneShot(_type, clip);
            else _overrideSource.PlayOneShot(clip);
        }
    }
}