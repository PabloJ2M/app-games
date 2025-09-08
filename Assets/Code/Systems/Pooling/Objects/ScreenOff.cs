namespace Unity.Pool
{
    public sealed class ScreenOff : PoolObject
    {
        private void OnBecameInvisible() => PoolReference.Release(this);
    }
}