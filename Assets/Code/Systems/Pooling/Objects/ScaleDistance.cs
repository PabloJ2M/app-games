using System.Collections;
using UnityEngine;

namespace Unity.Pool
{
    public class ScaleDistance : PoolObjectOnSpline
    {
        [SerializeField] private AnimationCurve _curve;

        protected override void UpdatePosition()
        {
            base.UpdatePosition();
            Transform.localScale = _curve.Evaluate(_currentTime) * Vector2.one;

            if (_currentTime < 1f) return;
            StartCoroutine(Release());
        }
        IEnumerator Release()
        {
            yield return new WaitForEndOfFrame();
            PoolReference.Release(this);
        }
    }
}