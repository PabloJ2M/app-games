namespace UnityEngine.Animations
{
    public class TweenPositionSwipe : TweenPosition
    {
        protected void OnEnable() => _transform.localPosition = _tweenCore.IsEnabled ? _from : _to;

        [ContextMenu("SwipeIn")] public void SwipeIn() => _tweenCore?.Play(true);
        [ContextMenu("SwipeOut")] public void SwipeOut() => _tweenCore?.Play(false);
    }
}