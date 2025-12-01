using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Random = UnityEngine.Random;

namespace Unity.Pool
{
    public interface IPoolManagerObjects
    {
        public IList<PoolObjectOnSpline> Spawned { get; }

        public event Action<PoolObjectBehaviour> OnSpawnObject;
        public event Action<PoolObjectBehaviour> OnDespawnObject;
    }

    public abstract class PoolManagerObjects : PoolBehaviuour<PoolObjectOnSpline>, IPoolManagerObjects
    {
        [SerializeField] protected int _capacity = 10;
        protected SplineContainer _spline;

        public event Action<PoolObjectBehaviour> OnSpawnObject;
        public event Action<PoolObjectBehaviour> OnDespawnObject;

        protected override void Awake()
        {
            base.Awake();
            _spline = GetComponentInChildren<SplineContainer>();
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