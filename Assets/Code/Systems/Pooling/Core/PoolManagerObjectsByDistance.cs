using UnityEngine;

namespace Unity.Pool
{
    public abstract class PoolManagerObjectsByDistance : PoolManagerObjects
    {
        [Header("Distance")]
        [SerializeField] private float _spaceDistance;

        private GameManager _gameManager;
        private float _traveled;

        protected override void Awake() { base.Awake(); _gameManager = GameManager.Instance; }
        protected virtual void Start() => OnSpawn();
        protected virtual void Update() => ForceDistance(_gameManager.Speed * Time.deltaTime);
        public void ForceDistance(float amount) => Math.Loop(ref _traveled, amount, _spaceDistance, OnSpawn);

        protected abstract void OnSpawn();
    }
}