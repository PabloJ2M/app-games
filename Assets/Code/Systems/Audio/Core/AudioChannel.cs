using System;

namespace UnityEngine.Audio
{
    public enum ChannelType
    {
        Music,
        SoundFx
    }
    public class AudioClipCache
    {
        public AudioClip clip;
        public byte refCount;
    }

    [Serializable] public class AudioChannel
    {
        [SerializeField] private ChannelType _type;
        [SerializeField] private AudioSource _source;
        [SerializeField] private string _mixerParam;

        private AudioMixerGroup _group;
        private AudioClip _defaultClip;

        public ChannelType Type => _type;

        public AudioChannel(ChannelType type)
        {
            _type = type;
            _mixerParam = _type.ToString();
        }
        public void Init()
        {
            _group = _source.outputAudioMixerGroup;
            _defaultClip = _source.clip;
        }

        public void SetVolume(float value) => _group.audioMixer.SetFloat(_mixerParam, Mathf.Log10(Mathf.Max(0.001f, value)) * 20f);
        public void Mute(bool value) => _source.mute = value;

        public void Play(AudioClip clip)
        {
            _source.clip = clip;
            _source.Play();
        }
        public void PlayDefault()
        {
            Play(_defaultClip);
        }
        public void PlayOneShot(AudioClip clip)
        {
            //_source.pitch = Random.Range(0.95f, 1.05f);
            _source?.PlayOneShot(clip);
        }
    }
}