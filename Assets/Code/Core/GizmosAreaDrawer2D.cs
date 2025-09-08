using UnityEngine;

[ExecuteAlways, SelectionBase, RequireComponent(typeof(Collider2D))]
public class GizmosAreaDrawer2D : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private Collider2D _shape;
    [SerializeField] private Color _color = Color.green;
    [SerializeField, Range(0f, 1f)] private float _alpha = 0.15f;

    private void Reset() => _shape = GetComponent<Collider2D>();
    private void OnDrawGizmos()
    {
        _color.a = _alpha;
        Gizmos.color = _color;

        if (!_shape) Reset();
        Vector2 position = (Vector2)transform.position + _shape.offset;

        if (_shape is BoxCollider2D box)
            Gizmos.DrawCube(position, box.size);

        if (_shape is CircleCollider2D circle)
            Gizmos.DrawSphere(position, circle.radius);
    }
#endif
}