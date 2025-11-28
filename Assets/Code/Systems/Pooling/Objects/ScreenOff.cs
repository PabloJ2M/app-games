namespace Unity.Pool
{
    public class ScreenOff : PoolObjectOnSpline
    {
        private bool _isVisible;

        private void OnBecameVisible() => _isVisible = true;
        private void OnBecameInvisible()
        {
            if (_isVisible)
                PoolReference.Release(this);
        }
    }
}