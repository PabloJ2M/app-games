using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public abstract class BodyBehaviour : MonoBehaviour
{
    protected GameManager _manager;
    protected Animator _animator;
    protected Rigidbody2D _rigidbody;
    protected Transform _transform;

    protected virtual void Awake()
    {
        _transform = transform;
        _manager = GameManager.Instance;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    protected virtual void HandleFirstInteraction()
    {
        if (_manager.IsEnabled) return;
        _manager?.Enable();

        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    public virtual void InteractTrigger()
    {
        _animator.SetTrigger("Interact");
        HandleFirstInteraction();
    }
    public void DeathTrigger()
    {
        _animator.SetTrigger("Death");
    }
}