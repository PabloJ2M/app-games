using Unity.Cinemachine;
using UnityEngine;

[RequireComponent(typeof(BodyBehaviour))]
public class DeathCondition : MonoBehaviour
{
    [SerializeField] private CinemachineShake _cameraEffect;
    [SerializeField] private Behaviour[] _components;

    private BodyBehaviour _body;
    private Vector2 _origin;

    private void Awake() { _origin = transform.position; _body = GetComponent<BodyBehaviour>(); }
    private void OnBecameInvisible() => Disable();
    private void OnTriggerEnter2D(Collider2D collision) => Disable();
    private void OnCollisionEnter2D(Collision2D collision) => Disable();

    public void Enable()
    {
        transform.position = _origin;
        foreach (var component in _components) component.enabled = true;
    }
    public void Disable()
    {
        foreach (var component in _components) component.enabled = false;
        GameManager.Instance.Disable();
        _cameraEffect?.Shake();
        _body?.DeathTrigger();
    }
}