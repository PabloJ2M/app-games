using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace UnityEngine.Audio
{
    public interface IAudioManager
    {
        public Task<AudioClip> LoadAudioAsset(AssetReferenceT<AudioClip> reference);
        public void UnloadAudioAsset(AssetReferenceT<AudioClip> reference);

        public void Play(ChannelType type, AudioClip key);
        public void PlayDefault(ChannelType type);
        public void PlayOneShot(ChannelType type, AudioClip key);
    }

    public interface IAudioSettings
    {
        public void SetVolume(ChannelType type, float volume);
        public void Mute(bool value);
    }
}