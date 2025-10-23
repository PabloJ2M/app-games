using System.Threading.Tasks;
using UnityEngine;

[ExecuteAlways, RequireComponent(typeof(SpriteRenderer))]
public class Shadow2D : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _parent;
    [SerializeField] private SpriteRenderer _shadow;
    [SerializeField] private Color _color;
    [SerializeField] private Vector2 _position = new(1f, -1f);

    private void Awake()
    {
        _parent = transform.parent.GetComponentInParent<SpriteRenderer>();
        _shadow = GetComponent<SpriteRenderer>();
    }
    private void Reset() => Awake();
    private void OnValidate() => OnEnable();

    private async void OnEnable()
    {
        await Task.Yield();
        if (!_shadow || !_parent) return;

        _shadow.color = _color;
        if (Application.isPlaying) _shadow.sprite = _parent.sprite;
        _shadow.transform.localPosition = 0.01f * _position;
    }
}