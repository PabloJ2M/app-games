using UnityEngine;

public abstract class FaceBehaviour : BodyBehaviour
{
    [SerializeField] protected float _threshold, _speed = 1;
    protected float _target;

    protected virtual void FixedUpdate()
    {
        _rigidbody.rotation = Mathf.Lerp(_rigidbody.rotation, -_target, _speed * Time.fixedDeltaTime);
    }
}