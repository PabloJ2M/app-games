using UnityEngine;
using UnityEngine.Animations;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Space _space = Space.World;
    [SerializeField] private Axis _axis = Axis.Z;
    [SerializeField, Range(-360f, 360f)] private float _angle = 10f;

    private Transform _transform;
    private Vector3 _axisVector;

    private void Awake() => _transform = transform;
    private void Start() => _axisVector = _axis.Get();
    private void FixedUpdate() => _transform.Rotate(_axisVector, _angle * Time.deltaTime, _space);
}