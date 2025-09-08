using UnityEngine;

namespace Unity.Cinemachine
{
    public class CinemachineShake : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private CinemachineBasicMultiChannelPerlin _noise;

        private void Awake() => _noise = GetComponent<CinemachineBasicMultiChannelPerlin>();
        private void Update() => LerpNormal();
        public void Shake() => _noise.AmplitudeGain = _noise.FrequencyGain = 5;

        private void LerpNormal()
        {
            float value = Mathf.MoveTowards(_noise.AmplitudeGain, 0, _speed * Time.deltaTime);
            _noise.AmplitudeGain = _noise.FrequencyGain = value;
        }
    }
}