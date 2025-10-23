using UnityEngine;

namespace Unity.Pool
{
    public class SpawnerPointRandom : SpawnerPoint
    {
        [SerializeField, Range(0, 1)] private float _threshold;

        protected override void OnSpawn()
        {
            if (Random.value < _threshold) return;
            base.OnSpawn();
        }
    }
}