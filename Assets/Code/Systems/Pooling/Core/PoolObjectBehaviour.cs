using UnityEngine;
using UnityEngine.Pool;

namespace Unity.Pool
{
    public abstract class PoolObjectBehaviour : MonoBehaviour
    {
        [field: SerializeField] public Transform Transform { get; private set; }

        public IObjectPool<PoolObjectBehaviour> PoolReference { protected get; set; }
        public ulong Index { protected get; set; }

        protected virtual void Reset() => Transform = transform;

        public virtual void Destroy() => PoolReference.Release(this);
        public virtual void Enable() => gameObject.SetActive(true);
        public virtual void Disable() => gameObject.SetActive(false);
    }
}