namespace UnityEngine.Animations
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class TweenTransform : TweenBehaviour<Vector3>
    {
        protected RectTransform _transform;
        protected Vector3 _from, _to;

        protected override void Awake() { base.Awake(); _transform = GetComponent<RectTransform>(); }
        protected override void OnUpdate(Vector3 value) { }
    }
}