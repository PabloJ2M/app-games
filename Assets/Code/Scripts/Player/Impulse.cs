using UnityEngine;
using UnityEngine.Events;

public class Impulse : Jump
{
    [SerializeField] protected UnityEvent<float> _displacePool;

    protected float _targetPoint = -1f;
    protected Vector2 _impulse;
    protected float _gravity;

    protected override void Awake()
    {
        base.Awake();
        _gravity = _rigidbody.gravityScale * Mathf.Abs(Physics2D.gravity.y);
    }
    protected virtual void Update()
    {
        if (_rigidbody.bodyType == RigidbodyType2D.Kinematic) return;

        float delta = Time.deltaTime;
        _impulse.y -= _gravity * delta;
        _impulse.x = Mathf.MoveTowards(_impulse.x, 0f, 5f * delta);

        //normal gravity
        if (_rigidbody.position.y <= _targetPoint - 0.01f) { _rigidbody.linearVelocity = _impulse; return; }
        
        //snap vertical gravity
        float displacement = _impulse.y * delta;
        _rigidbody.position = new(_rigidbody.position.x, _targetPoint + displacement);
        _rigidbody.linearVelocityX = _impulse.x;
        _rigidbody.linearVelocityY = 0f;

        if (_impulse.y > 0) _displacePool.Invoke(displacement * 2);
        else _rigidbody.position = new(_rigidbody.position.x, _targetPoint - 0.01f);
    }

    public void JumpDirection(int direction)
    {
        if (!enabled) return;
        InteractTrigger();

        _impulse = new Vector2(direction, 2) * _force;
        _transform.localScale = new(direction, 1, 1);
    }
}