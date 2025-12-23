using UnityEngine;
using Unity.Mathematics;

namespace Environment
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private float _speedMultiply = 1;
        [SerializeField] private float2 _direction = float2.zero;

        private const string _id = "_TextureOffset";
        private Material _material;
        private float2 _tileSize;

        private void Start()
        {
            var render = GetComponent<SpriteRenderer>();
            float2 units = render.sprite.rect.size / render.sprite.pixelsPerUnit;

            _tileSize = _direction * 0.1f * ((float2)render.size / units);
            _material = render.material;
        }
        private void OnEnable() => GameManager.Instance.onSpeedUpdated.AddListener(AddSpeedConstant);
        private void OnDisable() => GameManager.Instance.onSpeedUpdated.RemoveListener(AddSpeedConstant);

        private void AddSpeedConstant(float amount) => AddSpeed(amount * Time.deltaTime);
        public void AddSpeed(float amount)
        {
            Vector2 movement = amount * _speedMultiply * _tileSize;
            if (movement == Vector2.zero) return;

            _material.SetVector(_id, (Vector2)_material.GetVector(_id) + movement);
        }
    }
}