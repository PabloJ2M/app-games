using Unity.Mathematics;

namespace UnityEngine.Animations
{
    public abstract class TweenTransform : TweenBehaviour<Vector3>
    {
        protected Transform _transform;
        protected float3 _from, _to;

        protected override void Awake()
        {
            base.Awake();
            _transform = transform;
        }
    }
}