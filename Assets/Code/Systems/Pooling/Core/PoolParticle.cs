using System.Collections;
using UnityEngine;

namespace Unity.Pool
{
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class PoolParticle : PoolObject
    {
        [SerializeField] private SpriteRenderer _render;
        [SerializeField, Range(0.1f, 10f)] private float _fadeSpeed = 1f;

        protected override void Reset()
        {
            base.Reset();
            _render = GetComponent<SpriteRenderer>();
        }

        public void SetImage(Sprite sprite) => _render.sprite = sprite;
        public void SetPosition(Vector2 position) => Transform.position = position;
        public void SetAlpha(float alpha)
        {
            Color color = _render.color;
            color.a = alpha;
            _render.color = color;
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