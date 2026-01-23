using System;
using UnityEngine;

namespace Unity.Pool
{
    public abstract class PoolManagerObjects : PoolBehaviuour<PoolObjectOnSpline>, IPoolManagerObjects
    {
        [SerializeField] protected int _capacity = 10;
        protected ISpline _spline;

        public virtual float SpeedMultiply { get; } = 1f;
        public event Action<PoolObjectBehaviour> OnSpawnObject;
        public event Action<PoolObjectBehaviour> OnDespawnObject;

        protected override void Awake()
        {
            base.Awake();
            _spline = GetComponentInChildren<ISpline>();
        }

        protected override PoolObjectOnSpline OnCreate(PoolObjectOnSpline prefab)
        {
            var clone = base.OnCreate(prefab);
            clone.Spline = _spline;
            return clone;
        }
        protected override void OnGet(PoolObjectBehaviour @object)
        {
            base.OnGet(@object);
            OnSpawnObject?.Invoke(@object);
        }
        protected override void OnRelease(PoolObjectBehaviour @object)
        {
            base.OnRelease(@object);
            OnDespawnObject?.Invoke(@object);
        }
    }
}