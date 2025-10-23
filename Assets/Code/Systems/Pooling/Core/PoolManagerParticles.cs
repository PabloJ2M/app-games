using UnityEngine;

namespace Unity.Pool
{
    [RequireComponent(typeof(IPoolManagerObjects))]
    public abstract class PoolManagerParticles : PoolBehaviuour<PoolParticle>
    {
        protected IPoolManagerObjects _spawner;

        protected override void Awake()
        {
            base.Awake();
            _spawner = GetComponent<IPoolManagerObjects>();
        }
    }
}