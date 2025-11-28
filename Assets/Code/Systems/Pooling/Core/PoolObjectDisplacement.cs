using UnityEngine;

namespace Unity.Pool
{
    [RequireComponent(typeof(IPoolManagerObjects))]
    public sealed class PoolObjectDisplacement : MonoBehaviour
    {
        private GameManager _gameManager;
        private IPoolManagerObjects _manager;

        private void Awake()
        {
            _gameManager = GameManager.Instance;
            _manager = GetComponent<IPoolManagerObjects>();
        }

        private void Update() => Translate(_gameManager.Speed);

        public void Translate(float speed) => Move(speed, Time.deltaTime);
        public void TranslateUnit() => Move(1f);

        public void Move(float speed, float delta = 1f)
        {
            if (speed == 0) return;

            foreach (var item in _manager.Spawned)
                item.AddDistance(speed * delta);
        }
    }
}