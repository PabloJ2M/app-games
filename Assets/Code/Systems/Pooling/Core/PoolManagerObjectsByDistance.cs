using UnityEngine;

namespace Unity.Pool
{
    public abstract class PoolManagerObjectsByDistance : PoolManagerObjects
    {
        [Header("Distance")]
        [SerializeField] private float _spaceDistance;
        [SerializeField] private float _speedMultiply;

        public override float SpeedMultiply => _speedMultiply;
        public float TraveledDistance => _traveled;
        public float SpaceDistance => _spaceDistance;

        private float _traveled;
        
        public void ResetDistanceTraveled() => _traveled = 0;
        public void ForceDistance(float amount) => Math.Loop(ref _traveled, amount * SpeedMultiply * Time.deltaTime, _spaceDistance, OnSpawn);
        public abstract void ChangeLastItem(Sprite sprite);

        protected abstract void OnSpawn();
    }
}