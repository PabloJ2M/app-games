using UnityEngine;
using UnityEngine.Events;
using Unity.Mathematics;

public class SwipePositions : BodyBehaviour
{
    [Header("Movement")]
    [SerializeField] protected Vector2 _clampMovement = new(-1f, 1f);
    [SerializeField] protected float _displacement = 1f;
    [SerializeField] protected bool _changeDirection = true;

    [Header("Overlaping Obstacles")]
    [SerializeField] private LayerMask _obstacleLayer;
    [SerializeField] private UnityEvent _onSwipe;

    protected readonly Vector3 _left = new(-1f, 1f, 1f), _right = Vector3.one;
    private bool _handleEvent;

    protected override void Awake()
    {
        base.Awake();
        _handleEvent = _onSwipe.GetPersistentEventCount() != 0;
    }

    protected virtual void SetPosition(float value)
    {
        if (_changeDirection) _transform.localScale = value > 0f ? _left : _right;
        _transform.PositionX(math.clamp(_transform.PositionX() + value, _clampMovement.x, _clampMovement.y));
        InteractTrigger();
    }
    private void OverlapPosition()
    {
        if (!_handleEvent) return;
        if (Physics2D.OverlapCircle(_transform.position, 0.5f, _obstacleLayer)) return;
        _onSwipe.Invoke();
    }

    public void Left()
    {
        SetPosition(-_displacement);
        OverlapPosition();
    }
    public void Right()
    {
        SetPosition(_displacement);
        OverlapPosition();
    }
}