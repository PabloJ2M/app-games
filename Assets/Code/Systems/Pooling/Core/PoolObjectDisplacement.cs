using UnityEngine;
using UnityEngine.Events;

namespace Unity.Pool
{
    [RequireComponent(typeof(IPoolManagerObjects))]
    public sealed class PoolObjectDisplacement : MonoBehaviour
    {
        [SerializeField] private Vector2 _direction;
        [SerializeField] private UnityEvent<float> _onDisplaceAmount;
        private IPoolManagerObjects _manager;

        private void Awake() => _manager = GetComponent<IPoolManagerObjects>();
        private void OnValidate() => _direction = new(Mathf.Clamp(_direction.x, -1, 1), Mathf.Clamp(_direction.y, -1, 1));

        public void Move(float speed)
        {
            if (speed == 0) return;

            Vector2 distance = speed * _direction;
            _onDisplaceAmount.Invoke(distance.magnitude);
            Translate(distance);
        }
        public void MoveUnit() => Move(1f);
        public void SimpleMove(float speed)
        {
            if (speed == 0) return;

            Vector2 smoothDistance = speed * Time.deltaTime * _direction;
            _onDisplaceAmount.Invoke(smoothDistance.magnitude);
            Translate(smoothDistance);
        }

        private void Translate(Vector2 distance)
        {
            foreach (var item in _manager.Spawned)
                item.Transform.Translate(distance);
        }
    }
}