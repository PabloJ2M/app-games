namespace Unity.Pool
{
    public class SpawnerPoint : PoolManagerObjectsByDistance
    {
        protected override void OnSpawn()
        {
            var obj = Pool.Get() as PoolObjectOnSpline;
            obj.SetTime(0);
        }
    }
}