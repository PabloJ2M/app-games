using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Unity.Pool
{
    public abstract class PoolBehaviuour : MonoBehaviour
    {
        [SerializeField] protected Transform _parent;
        [SerializeField] protected PoolObject _prefab;

        public IList<PoolObject> Spawned { get; set; }

        protected IObjectPool<PoolObject> Pool;
        protected int LastIndex => Spawned.Count - 1;

        protected virtual void Awake()
        {
            Spawned = new List<PoolObject>();
            Pool = new ObjectPool<PoolObject>(OnCreate, OnGet, OnRelease, OnDestroyObject);
        }
        protected virtual void Reset() => _parent = transform;

        protected virtual PoolObject OnCreate()
        {
            var obj = Instantiate(_prefab, _parent);
            obj.PoolReference = Pool;
            return obj;
        }
        protected virtual void OnGet(PoolObject @object)
        {
            @object.Enable();
            Spawned?.Add(@object);
        }
        protected virtual void OnRelease(PoolObject @object)
        {
            @object.Disable();
            Spawned?.Remove(@object);
        }
        protected virtual void OnDestroyObject(PoolObject @object) => Destroy(@object.gameObject);
    }
}
