using System.Collections;

namespace Unity.Pool
{
    public class SpawnerQueueVertical : SpawnerQueue
    {
        protected override IEnumerator Start()
        {
            yield return _emptySpaceAvailable;

            var obstacle = Pool.Get();
            float target = LastIndex <= 0 ? transform.PositionY() : (Spawned[LastIndex - 1].Transform.PositionY() + 1);

            obstacle.Transform.PositionY(target);
            _index++;

            StartCoroutine(Start());
        }
    }
}