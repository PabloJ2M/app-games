using UnityEngine.UI;

namespace UnityEngine.Audio
{
    [RequireComponent(typeof(Button))]
    public class AudioEmitterButton : AudioEmitterRandom
    {
        protected override void Awake()
        {
            base.Awake();
            Button button = GetComponent<Button>();

            switch (_type)
            {
                case ChannelType.Music: button.onClick.AddListener(Play); break;
                case ChannelType.SoundFx: button.onClick.AddListener(PlayOneShot); break;
            }
        }
    }
}