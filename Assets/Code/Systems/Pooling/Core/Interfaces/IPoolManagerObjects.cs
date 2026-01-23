using System;
using System.Collections.Generic;

namespace Unity.Pool
{
    public interface IPoolManagerObjects
    {
        float SpeedMultiply { get; }
        IList<PoolObjectOnSpline> Spawned { get; }

        event Action<PoolObjectBehaviour> OnSpawnObject;
        event Action<PoolObjectBehaviour> OnDespawnObject;
    }
}