using UnityEngine;

public class ScreenConfinner : MonoBehaviour
{
    [SerializeField] private bool _clampX = true, _clampY = true;
    [SerializeField] private float _threshold = 0.5f;

    private Transform _transform;
    private Vector2 _screenLimit;

    private void Awake()
    {
        Vector2 target = Camera.main.ViewportToWorldPoint(Vector2.one);
        
        _transform = transform;
        _screenLimit = target - Vector2.one * _threshold;
    }
    private void Update()
    {
        if (_clampX) _transform.ClampPositionX(-_screenLimit.x, _screenLimit.x);
        if (_clampY) _transform.ClampPositionY(-_screenLimit.y, _screenLimit.y);
    }
}