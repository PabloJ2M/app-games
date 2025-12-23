using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;

namespace UnityEngine.Audio
{
    public class AudioManager : SingletonBasic<AudioManager>, IAudioManager, IAudioSettings
    {
        [SerializeField] private AudioChannel[] _channels = { new(ChannelType.Music), new(ChannelType.SoundFx) };

        private Dictionary<ChannelType, AudioChannel> _channelMap = new();
        private Dictionary<AssetReference, AudioClipCache> _cache = new();

        protected override void Awake()
        {
            base.Awake();

            foreach (var channel in _channels)
            {
                channel.Init();
                _channelMap.Add(channel.Type, channel);
            }
        }

        public async Task<AudioClip> LoadAudioAsset(AssetReferenceT<AudioClip> reference)
        {
            if (_cache.TryGetValue(reference, out var cache))
            {
                cache.refCount++;
                return cache.clip;
            }

            var clip = await reference.LoadAssetAsync().Task;
            _cache.Add(reference, new() { clip = clip, refCount = 1 });
            return clip;
        }
        public void UnloadAudioAsset(AssetReferenceT<AudioClip> reference)
        {
            if (!_cache.TryGetValue(reference, out var cache)) return;
            cache.refCount--;

            if (cache.refCount > 0) return;

            reference.ReleaseAsset();
            _cache.Remove(reference);
        }

        public void Play(ChannelType type, AudioClip clip) => _channelMap[type].Play(clip);
        public void PlayDefault(ChannelType type) => _channelMap[type].PlayDefault();
        public void PlayOneShot(ChannelType type, AudioClip clip) => _channelMap[type].PlayOneShot(clip);

        public void SetVolume(ChannelType type, float volume) => _channelMap[type].SetVolume(volume);
        public void Mute(bool value)
        {
            foreach (var channel in _channels)
                channel.Mute(value);
        }
    }
}