using UnityEngine;

namespace Unity.Pool
{
    public class SpawnerVertical : SpawnerPoint
    {
        [SerializeField] private float _spawnHeight;

        protected override void OnSpawn()
        {
            var obj = GetPrefabRandom();
            obj.Transform.PositionX(transform.position.x);
            obj.Transform.PositionY(transform.position.y + Random.Range(-_spawnHeight, _spawnHeight));
        }

        private void OnDrawGizmos()
        {
            Vector2 up = transform.position + (Vector3.up * _spawnHeight);
            Vector2 down = transform.position + (Vector3.down * _spawnHeight);
            Gizmos.color = Color.red; Gizmos.DrawLine(up, down);
        }
    }
}