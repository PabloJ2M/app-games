using UnityEngine;

public class FaceGravity : FaceBehaviour
{
    [SerializeField, Range(-180, 180)] private float _up, _down;

    protected override void FixedUpdate()
    {
        if (_rigidbody.linearVelocityY == 0) return;

        _target = Mathf.Lerp(_down, _up, _rigidbody.linearVelocityY + _threshold);
        base.FixedUpdate();
    }
}