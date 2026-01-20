using Unity.Mathematics;

namespace UnityEngine.Animations
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class TweenRectTransform : TweenBehaviour<Vector3>
    {
        protected RectTransform _transform;
        protected float3 _from, _to;

        protected override void Awake()
        {
            base.Awake();
            _transform = transform as RectTransform;
        }
    }
}