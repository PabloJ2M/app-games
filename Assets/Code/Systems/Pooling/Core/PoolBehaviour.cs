using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Unity.Pool
{
    public abstract class PoolBehaviuour<T> : MonoBehaviour where T : PoolObjectBehaviour
    {
        [SerializeField] protected Transform _parent;
        [SerializeField] protected T[] _prefabs;

        protected Dictionary<T, ObjectPool<PoolObjectBehaviour>> Pools = new();
        protected int LastIndex => Spawned.Count - 1;

        public IList<T> Spawned { get; set; } = new List<T>();

        protected virtual void Reset() => _parent = transform;
        protected virtual void Awake()
        {
            foreach (var prefab in _prefabs)
                Pools.Add(prefab, new(() => OnCreate(prefab), OnGet, OnRelease, OnDestroyObject));
        }

        protected virtual T OnCreate(T prefab)
        {
            var obj = Instantiate(prefab, _parent);
            obj.PoolReference = Pools[prefab];
            return obj;
        }
        protected virtual void OnGet(PoolObjectBehaviour @object)
        {
            @object.Enable();
            Spawned?.Add(@object as T);
        }
        protected virtual void OnRelease(PoolObjectBehaviour @object)
        {
            @object.Disable();
            Spawned?.Remove(@object as T);
        }
        protected virtual void OnDestroyObject(PoolObjectBehaviour @object) => Destroy(@object.gameObject);

        protected PoolObjectBehaviour GetPrefabRandom()
        {
            var prefab = _prefabs[Random.Range(0, _prefabs.Length)];
            return Pools[prefab].Get();
        }
    }
}