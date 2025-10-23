using UnityEngine;

namespace Unity.Pool
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class BrickParticle : PoolParticle
    {
        private Rigidbody2D _rigidbody;

        protected override void Awake() { base.Awake(); _rigidbody = GetComponent<Rigidbody2D>(); }
        public void DropDirection(Vector2 direction)
        {
            _rigidbody.linearVelocity = direction;

            _rigidbody.SetRotation(0);
            _rigidbody.AddTorque(direction.x * 10);
            
            StartCoroutine(FadeOut());
        }

        public override void Enable()
        {
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            SetAlpha(1f);
            base.Enable();
        }
        public override void Disable()
        {
            _rigidbody.bodyType = RigidbodyType2D.Static;
            base.Disable();
        }
    }
}