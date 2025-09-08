using UnityEngine;

namespace Unity.Pool
{
    public abstract class PoolManagerObjectsByDistance : PoolManagerObjects
    {
        [Header("Distance")]
        [SerializeField] private float _spaceDistance;
        private float _traveled;

        public float Speed { private get; set; }

        protected virtual void Start() => OnSpawn();
        protected virtual void Update() => ForceDistance(Speed * Time.deltaTime);
        public void ForceDistance(float amount) => Math.Loop(ref _traveled, amount, _spaceDistance, OnSpawn);

        protected abstract void OnSpawn();
    }
}