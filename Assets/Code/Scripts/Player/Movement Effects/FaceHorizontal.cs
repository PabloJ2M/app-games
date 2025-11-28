using UnityEngine;

public class FaceHorizontal : FaceBehaviour
{
    [SerializeField, Range(-180, 180)] private float _left, _right;

    protected override void FixedUpdate()
    {
        if (_rigidbody.linearVelocityX == 0) return;

        _target = Mathf.Lerp(_left, _right, _rigidbody.linearVelocityX + _threshold);
        base.FixedUpdate();
    }
}