using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Unity.Pool
{
    public sealed class Stack : PoolObjectOnSpline
    {
        [Serializable] private struct BlockComponent
        {
            public Collider2D collider;
            public Sprite image;
        }

        [Header("Renderer")]
        [SerializeField] private SpriteRenderer _render;
        [SerializeField] private BlockComponent[] _blocks;

        private Sprite _default;
        private int _index;

        public Sprite CurrentSprite { get; private set; }

        private void Awake() => _default = _render.sprite;
        protected override void Reset()
        {
            base.Reset();
            _render = GetComponent<SpriteRenderer>();
        }

        public override void Enable()
        {
            base.Enable();
            if (Index % 2 == 0) { CurrentSprite = _render.sprite = _default; return; }

            _index = Random.Range(0, _blocks.Length);
            _blocks[_index].collider.enabled = true;
            CurrentSprite = _render.sprite = _blocks[_index].image;
        }
        public override void Disable()
        {
            base.Disable();
            _blocks[_index].collider.enabled = false;
        }
    }
}