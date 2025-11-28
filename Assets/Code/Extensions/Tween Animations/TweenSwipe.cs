namespace UnityEngine.Animations
{
    public class TweenSwipe : TweenPosition
    {
        protected override void OnStart()
        {
            base.OnStart();

            if (!_tweenCore.IsEnabled)
                _transform.localPosition = _to;
        }

        [ContextMenu("SwipeIn")] public void SwipeIn() => _tweenCore?.Play(true);
        [ContextMenu("SwipeOut")] public void SwipeOut() => _tweenCore?.Play(false);
        [ContextMenu("Swap Animation")] public void SwapAnimation() => _tweenCore?.SwapTweenAnimation();
    }
}