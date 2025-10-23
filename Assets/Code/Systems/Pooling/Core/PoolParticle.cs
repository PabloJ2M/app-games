using System.Collections;
using UnityEngine;

namespace Unity.Pool
{
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class PoolParticle : PoolObjectBehaviour
    {
        [SerializeField] private SpriteRendererAlpha _render;
        [SerializeField, Range(0.1f, 10f)] private float _fadeSpeed = 1f;
        private SpriteRendererAlpha[] _children;

        protected virtual void Awake() => _children = GetComponentsInChildren<SpriteRendererAlpha>();
        protected override void Reset() { base.Reset(); _render = GetComponent<SpriteRendererAlpha>(); }

        public void SetImage(Sprite sprite) => _render.SetSprite(sprite);
        public void SetPosition(Vector2 position) => Transform.position = position;
        public void SetAlpha(float alpha)
        {
            foreach (var render in _children)
                render.SetAlpha(alpha);
        }

        protected IEnumerator FadeOut()
        {
            float time = 1f;
            while (time > 0f)
            {
                SetAlpha(time);
                yield return null;
                time -= Time.deltaTime * _fadeSpeed;
            }

            Destroy();
        }
    }
}