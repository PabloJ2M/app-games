using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Unity.Pool
{
    public sealed class Brick : PoolObjectOnSpline
    {
        [Serializable] private struct BlockComponent
        {
            public Collider2D collider;
            public Sprite[] image;
        }

        [SerializeField] private SpriteRenderer _render;
        [SerializeField] private Sprite _default;
        [SerializeField] private BlockComponent[] _blocks;

        public Sprite CurrentSprite { get; private set; }

        public override void Enable()
        {
            base.Enable();
            bool isDefault = Index % 2 == 0;
            if (isDefault) { CurrentSprite = _render.sprite = _default; return; }

            int index = Random.Range(0, _blocks.Length);
            var spriteIndex = Random.Range(0, _blocks[index].image.Length);

            CurrentSprite = _render.sprite = _blocks[index].image[spriteIndex];
            _blocks[index].collider.enabled = true;
        }
        public override void Disable()
        {
            base.Disable();
            foreach (var block in _blocks)
                block.collider.enabled = false;
        }
    }
}