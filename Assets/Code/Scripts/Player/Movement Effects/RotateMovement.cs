using UnityEngine;

public class RotateMovement : BodyBehaviour
{
    private const float _left = -45f, _right = 45f;
    private float _lastPosition;

    private void Update()
    {
        float current = _transform.PositionX();
        float direction = Mathf.Clamp(current - _lastPosition, -1f, 1f);
        
        if (direction == 0) _rigidbody.SetRotation(0);
        else _rigidbody.SetRotation(direction > 0 ? _left : _right);

        _lastPosition = current;
    }
}