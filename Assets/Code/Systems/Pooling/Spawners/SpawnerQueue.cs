using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.Pool
{
    public abstract class SpawnerQueue : PoolManagerObjects
    {
        [SerializeField] private float _enqueueDelay;
        [SerializeField] private UnityEvent _onEnqueue;

        protected WaitUntil _emptySpaceAvailable;
        protected ulong _index;

        protected override void Awake()
        {
            _emptySpaceAvailable = new(() => Spawned.Count < _capacity);
            base.Awake();
        }
        protected abstract IEnumerator Start();

        protected override void OnGet(PoolObject @object)
        {
            @object.Index = _index;
            base.OnGet(@object);
        }
        public void Enqueue()
        {
            Pool.Release(Spawned[0]);
            _onEnqueue.Invoke();
        }
    }
}