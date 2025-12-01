using System.Collections;

namespace Unity.Pool
{
    public class SpawnerQueueVertical : SpawnerQueue
    {
        protected override IEnumerator Start()
        {
            yield return _emptySpaceAvailable;

            var obstacle = GetPrefabRandom() as PoolObjectOnSpline;
           
            float target = LastIndex <= 0 ? 0f : (Spawned[LastIndex - 1].Transform.LocalPositionY() + 1f);
            obstacle.SetDistance(target);
            _index++;

            StartCoroutine(Start());
        }
    }
}