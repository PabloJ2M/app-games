using Unity.Mathematics;

namespace UnityEngine.Animations
{
    public class TweenCustomVector : TweenCustom
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