using UnityEngine;

namespace Unity.Pool
{
    public class SpawnerPoint : PoolManagerObjectsByDistance
    {
        protected override void OnSpawn()
        {
            var obj = GetPrefabRandom() as PoolObjectOnSpline;
            obj.SetTime(0);
        }
        public override void ChangeLastItem(Sprite sprite)
        {
            
        }
    }
}