using UnityEngine;
using Unity.Mathematics;

public class SwipePositionsLerp : SwipePositions
{
    [Header("Lerp Speed")]
    [SerializeField] private float _speed;
    private float _targetPosition;

    private void Update()
    {
        if (_targetPosition == _transform.PositionX()) return;
        _transform.PositionX(Mathf.MoveTowards(_transform.PositionX(), _targetPosition, _speed * Time.deltaTime));
    }
    protected override void SetPosition(float value)
    {
        if (_changeDirection) _transform.localScale = value > 0f ? _left : _right;
        _targetPosition = math.clamp(_targetPosition + value, _clampMovement.x, _clampMovement.y);
        InteractTrigger();
    }
}