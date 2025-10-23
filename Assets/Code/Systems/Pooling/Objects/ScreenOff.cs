namespace Unity.Pool
{
    public sealed class ScreenOff : PoolObjectOnSpline
    {
        private void OnBecameInvisible() => PoolReference.Release(this);
    }
}