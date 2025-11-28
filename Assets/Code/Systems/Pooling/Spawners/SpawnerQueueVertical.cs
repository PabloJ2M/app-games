using System.Linq;
using System.Collections;
using UnityEngine;

namespace Unity.Pool
{
    public class SpawnerQueueVertical : SpawnerQueue
    {
        protected override IEnumerator Start()
        {
            yield return _emptySpaceAvailable;

            var obstacle = Pool.Get() as PoolObjectOnSpline;
            
            float target = LastIndex <= 0 ? transform.PositionY() : (Spawned[LastIndex - 1].Transform.LocalPositionY() + 1);
            obstacle.SetDistance(target);
            _index++;
            
            //Debug.Log(Spawned[LastIndex].Transform.LocalPositionY(), Spawned[LastIndex]);

            StartCoroutine(Start());
        }
    }
}