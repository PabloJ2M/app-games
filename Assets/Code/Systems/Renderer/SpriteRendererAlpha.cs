using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRendererAlpha : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _render;
    private float _defaultAlpha;

    private void Awake() { _render = GetComponent<SpriteRenderer>(); _defaultAlpha = _render.color.a; }
    private void Reset() => Awake();

    public void SetSprite(Sprite sprite) => _render.sprite = sprite;
    public void SetAlpha(float value)
    {
        Color color = _render.color;
        color.a = math.lerp(value, _defaultAlpha, 0f);
        _render.color = color;
    }
}