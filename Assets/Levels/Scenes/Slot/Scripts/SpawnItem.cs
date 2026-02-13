using Unity.Pool;
using UnityEngine;

namespace Gameplay.Slot
{
    public class SpawnItem : SpawnerPoint
    {
        protected override void OnSpawn()
        {
            var obj = GetPrefabRandom() as PoolObjectOnSpline;
            var icon = obj.GetComponent<SetIcon>();

            icon.SetImageRandom();
            obj.SetDistance(TraveledDistance);
        }
        public override void ChangeLastItem(Sprite sprite)
        {
            Spawned[Spawned.Count - 1].GetComponent<SetIcon>().SetSpecificItem(sprite);
        }
    }
}