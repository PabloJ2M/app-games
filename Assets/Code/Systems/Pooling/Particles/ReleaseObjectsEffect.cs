namespace Unity.Pool
{
    public abstract class ReleaseObjectsEffect : PoolManagerParticles
    {
        private void OnEnable() => _spawner.OnDespawnObject += OnReleaseObjectEffect;
        private void OnDisable() => _spawner.OnDespawnObject -= OnReleaseObjectEffect;

        protected abstract void OnReleaseObjectEffect(PoolObjectBehaviour @object);
    }
}