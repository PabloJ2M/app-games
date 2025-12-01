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

        protected override void OnGet(PoolObjectBehaviour @object)
        {
            @object.Index = _index;
            base.OnGet(@object);
        }
        public void Enqueue()
        {
            Spawned[0].Destroy();
            _onEnqueue.Invoke();
        }
    }
}