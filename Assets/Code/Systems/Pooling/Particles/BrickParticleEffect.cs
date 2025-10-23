using UnityEngine;

namespace Unity.Pool
{
    public sealed class BrickParticleEffect : ReleaseObjectsEffect
    {
        [SerializeField] private float _force = 1f;
        private Transform _player;

        protected override void Awake()
        {
            base.Awake();
            _player = GameObject.FindWithTag("Player").transform;
        }
        protected override void OnReleaseObjectEffect(PoolObjectBehaviour @object)
        {
            var brick = @object as Brick;
            var particle = Pool.Get() as BrickParticle;

            particle.SetImage(brick.CurrentSprite);
            particle.SetPosition(brick.Transform.position);
            particle.DropDirection(_force * new Vector2(-_player.PositionX(), 1f));
        }
    }
}