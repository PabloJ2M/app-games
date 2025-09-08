using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Pool
{
    public interface IPoolManagerObjects
    {
        public IList<PoolObject> Spawned { get; set; }

        public event Action<PoolObject> OnSpawnObject;
        public event Action<PoolObject> OnDespawnObject;
    }

    public abstract class PoolManagerObjects : PoolBehaviuour, IPoolManagerObjects
    {
        [SerializeField] protected int _capacity = 10;

        public event Action<PoolObject> OnSpawnObject;
        public event Action<PoolObject> OnDespawnObject;

        protected override void OnGet(PoolObject @object)
        {
            base.OnGet(@object);
            OnSpawnObject?.Invoke(@object);
        }
        protected override void OnRelease(PoolObject @object)
        {
            base.OnRelease(@object);
            OnDespawnObject?.Invoke(@object);
        }
    }
}