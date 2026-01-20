using UnityEngine;

public class StretchAnimation : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private Vector3 _scaleAnimation = Vector3.one;
    private Transform _transform;

    private void Awake() => _transform = transform;
    private void Update()
    {
        if (_transform.localScale != Vector3.one)
            _transform.localScale = Vector3.Lerp(_transform.localScale, Vector3.one, Time.deltaTime * _speed);
    }

    public void OnTriggerAnimation() => _transform.localScale = _scaleAnimation;
    public void OnTriggerAnimation(Vector3 scale) => _transform.localScale = scale;
}