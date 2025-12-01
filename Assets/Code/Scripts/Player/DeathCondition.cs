using UnityEngine;
using UnityEngine.Animations;
using Unity.Cinemachine;

[RequireComponent(typeof(BodyBehaviour))]
public class DeathCondition : MonoBehaviour
{
    [SerializeField] private CinemachineShake _cameraEffect;
    [SerializeField] private TweenCanvasGroup _hitEffect;
    [SerializeField] private SpriteRenderer _render;

    [SerializeField] private Behaviour[] _components;

    private BodyBehaviour _body;
    private Vector2 _origin;
    private Color _default;
    private bool _isDeath;

    private void Awake() { _origin = transform.position; _body = GetComponent<BodyBehaviour>(); }
    private void Start() => _default = _render.color;
    private void OnBecameInvisible() => Disable();
    private void OnTriggerEnter2D(Collider2D collision) => Disable();
    private void OnCollisionEnter2D(Collision2D collision) => Disable();

    public void Enable()
    {
        _isDeath = false;
        transform.position = _origin;
        foreach (var component in _components) component.enabled = true;
    }
    public void Disable()
    {
        if (_isDeath) return;
        foreach (var component in _components) component.enabled = false;

        Invoke(nameof(NormalColor), 0.2f);
        GameManager.Instance.Disable();
        Time.timeScale = 0.4f;
        
        _render.color = Color.black;
        _cameraEffect?.Shake();
        _hitEffect?.FadeIn();

        _body?.DeathTrigger();
        _isDeath = true;
    }
    private void NormalColor()
    {
        _render.color = _default;
        Time.timeScale = 1f;
    }
}