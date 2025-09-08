using UnityEngine;

namespace Unity.Pool
{
    public class SpawnerHorizontal : PoolManagerObjectsByDistance
    {
        [SerializeField] private float _spawnWidth;

        protected override void OnSpawn()
        {
            var obj = Pool.Get();
            obj.Transform.PositionX(transform.position.x + Random.Range(-_spawnWidth, _spawnWidth));
            obj.Transform.PositionY(transform.position.y);
        }

        private void OnDrawGizmos()
        {
            Vector2 left = transform.position + (Vector3.left * _spawnWidth);
            Vector2 right = transform.position + (Vector3.right * _spawnWidth);
            Gizmos.color = Color.red; Gizmos.DrawLine(left, right);
        }
    }
}