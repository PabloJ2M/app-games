using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Unity.Pool
{
    public abstract class PoolBehaviuour<T> : MonoBehaviour where T : PoolObjectBehaviour
    {
        [SerializeField] protected Transform _parent;
        [SerializeField] protected T _prefab;

        public IList<T> Spawned { get; set; } = new List<T>();

        protected IObjectPool<PoolObjectBehaviour> Pool;
        protected int LastIndex => Spawned.Count - 1;

        protected virtual void Awake() => Pool = new ObjectPool<PoolObjectBehaviour>(OnCreate, OnGet, OnRelease, OnDestroyObject);
        protected virtual void Reset() => _parent = transform;

        protected virtual T OnCreate()
        {
            var obj = Instantiate(_prefab, _parent);
            obj.PoolReference = Pool;
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
    }
}