using UnityEngine;
using UnityEngine.Events;

public class JumpAir : Jump
{
    [SerializeField] protected UnityEvent<float> _displacePool;

    protected float _targetPoint = -1f;
    protected Vector2 _impulse;
    protected float _gravity;
    private bool _hasReachLimit;

    protected override void Awake()
    {
        base.Awake();
        _targetPoint = _transform.PositionY();
        _gravity = _rigidbody.gravityScale * Mathf.Abs(Physics2D.gravity.y);
    }
    protected virtual void Update()
    {
        if (_rigidbody.bodyType == RigidbodyType2D.Kinematic) return;

        float delta = Time.deltaTime;
        _impulse.y -= _gravity * delta;
        _impulse.x = Mathf.MoveTowards(_impulse.x, 0f, 5f * delta);

        //normal gravity
        if (!_hasReachLimit && _rigidbody.position.y < _targetPoint - 0.01f)
        {
            _rigidbody.linearVelocity = _impulse;
            return;
        }
        
        //snap vertical gravity
        _rigidbody.position = new(_rigidbody.position.x, _targetPoint);
        _rigidbody.linearVelocityX = _impulse.x;
        _rigidbody.linearVelocityY = 0f;

        _hasReachLimit = _impulse.y > 0;
        if (_hasReachLimit) _displacePool.Invoke(_impulse.y);
        else _rigidbody.position = new(_rigidbody.position.x, _targetPoint - 0.01f);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) _targetPoint = transform.PositionY();
        Vector2 target = new(0, _targetPoint);
        Vector2 length = Vector2.right * 2;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(target - length, target + length);
    }
#endif

    public void JumpDirection(int direction)
    {
        if (!enabled) return;
        InteractTrigger();

        _impulse = new Vector2(direction, 2) * _force;
        //_transform.eulerAngles = new(0, direction > 0 ? 0 : -180, 0);
    }
}