using UnityEngine.UI;

namespace UnityEngine.Audio
{
    public class AudioSettings : MonoBehaviour
    {
        [SerializeField] private ChannelType _channel;
        [SerializeField] private Slider _onValueChanged;

        private IAudioSettings _manager;

        private void Awake() => _manager = AudioManager.Instance;
        private void Start() => _onValueChanged.value = PlayerPrefs.GetFloat(_channel.ToString());
        private void OnEnable() => _onValueChanged.onValueChanged.AddListener(OnPerforme);
        private void OnDisable() => _onValueChanged.onValueChanged.RemoveListener(OnPerforme);

        private void OnPerforme(float value)
        {
            PlayerPrefs.SetFloat(_channel.ToString(), value);
            _manager.SetVolume(_channel, value);
        }
    }
}