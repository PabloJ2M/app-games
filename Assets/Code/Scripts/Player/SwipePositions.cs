using UnityEngine;
using UnityEngine.Events;

public class SwipePositions : BodyBehaviour
{
    [Header("Movement")]
    [SerializeField] private LayerMask _obstacle;
    [SerializeField] private UnityEvent _onSwipe;

    private float _vertical, _horizontal;

    protected override void Awake()
    {
        base.Awake();
        _vertical = _rigidbody.position.y;
        _horizontal = Mathf.Abs(_rigidbody.position.x);
    }

    private void SetPosition(float value)
    {
        _transform.localScale = new(value > 0 ? -1 : 1, 1, 1);
        _transform.position = new(value, _vertical);
        InteractTrigger();
    }

    public void Left()
    {
        SetPosition(-_horizontal);

        if (!Physics2D.OverlapCircle(_transform.position, 0.5f, _obstacle))
            _onSwipe.Invoke();
    }
    public void Right()
    {
        SetPosition(_horizontal);

        if (!Physics2D.OverlapCircle(_transform.position, 0.5f, _obstacle))
            _onSwipe.Invoke();
    }
}