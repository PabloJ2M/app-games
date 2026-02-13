using UnityEngine;

namespace Gameplay.Slot
{
    public class SetIcon : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _render;
        [SerializeField] private Sprite[] _items;

        public void SetImageRandom() => _render.sprite = _items[Random.Range(0, _items.Length)];
        public void SetSpecificItem(Sprite sprite) => _render.sprite = sprite;
    }
}