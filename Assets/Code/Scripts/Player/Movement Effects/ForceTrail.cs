using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class ForceTrail : MonoBehaviour
{
    [SerializeField] private float _multiplier = 1f;
    private TrailRenderer _trail;

    private void Awake() => _trail = GetComponent<TrailRenderer>();
    private void Update() => ApplyExternalForce(_multiplier);

    public void ApplyExternalForce(float force)
    {
        if (_trail.positionCount == 0) return;

        for (int i = 0; i < _trail.positionCount; i++)
        {
            Vector2 position = _trail.GetPosition(i);
            position.y -= force * Time.deltaTime;
            _trail.SetPosition(i, position);
        }
    }
}