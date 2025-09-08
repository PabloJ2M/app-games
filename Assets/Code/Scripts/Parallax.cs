using UnityEngine;

namespace Environment
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private float _speedMultiply = 1;
        [SerializeField] private Vector2 _direction = Vector2.zero;

        private string _id = "_TextureOffset";
        private Material _material;

        private void Start() => _material = GetComponent<SpriteRenderer>().material;
        private void OnEnable() => GameManager.Instance._onSpeedUpdated.AddListener(AddSpeedConstant);
        private void OnDisable() => GameManager.Instance._onSpeedUpdated.RemoveListener(AddSpeedConstant);

        private void AddSpeedConstant(float amount) => AddSpeed(amount * Time.deltaTime);
        public void AddSpeed(float amount)
        {
            Vector2 movement = amount * _speedMultiply * 0.01f * _direction;
            if (movement == Vector2.zero) return;

            _material.SetVector(_id, (Vector2)_material.GetVector(_id) + movement);
        }
    }
}