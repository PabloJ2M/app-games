using UnityEngine;

public class FaceGravity : BodyBehaviour
{
    [SerializeField, Range(-180, 180)] private float _up, _down;
    [SerializeField] private float _threshold, _speed = 1;

    private void FixedUpdate()
    {
        if (_rigidbody.linearVelocityY == 0) return;

        float target = Mathf.Lerp(_down, _up, _rigidbody.linearVelocityY + _threshold);
        _rigidbody.rotation = Mathf.Lerp(_rigidbody.rotation, -target, _speed * Time.fixedDeltaTime);
    }
}