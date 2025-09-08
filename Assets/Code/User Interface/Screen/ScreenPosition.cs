using UnityEngine;

public class ScreenPosition : MonoBehaviour
{
    [SerializeField] private bool _snapX = true, _snapY = true;
    [SerializeField, Range(0, 10)] private float _threshold;

    [SerializeField] private Vector2 _viewport = new(0.5f, 0.5f);

    private void Awake()
    {
        if (!_snapX && !_snapY) return;

        Vector2 target = Camera.main.ViewportToWorldPoint(_viewport);
        Vector2 result = target + target.normalized * _threshold;
        if (_snapX) transform.PositionX(result.x);
        if (_snapY) transform.PositionY(result.y);
    }
    private void OnValidate()
    {
        Vector2 viewport = _viewport;
        viewport.x = Mathf.Clamp01(_viewport.x);
        viewport.y = Mathf.Clamp01(_viewport.y);
        _viewport = viewport;
    }
}