using UnityEngine;

public class JumpGround : Jump
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundDistance;

    private RaycastHit2D[] _hits = new RaycastHit2D[1];
    private bool _isGrounded = true;

    private void FixedUpdate()
    {
        Physics2D.RaycastNonAlloc(_transform.position, Vector2.down, _hits, 10, _groundLayer);
        if (_hits.Length == 0) return;

        _isGrounded = _hits[0].distance <= _groundDistance;
    }
    public override void InteractTrigger()
    {
        if (!_isGrounded) return;
        base.InteractTrigger();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _groundDistance);
    }
#endif
}