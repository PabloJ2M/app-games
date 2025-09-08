using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public abstract class BodyBehaviour : MonoBehaviour
{
    protected Animator _animator;
    protected Rigidbody2D _rigidbody;
    protected Transform _transform;

    private bool _isPlaying;

    protected virtual void Awake()
    {
        _transform = transform;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
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

    private void HandleFirstInteraction()
    {
        if (_isPlaying) return;

        GameManager.Instance?.Enable();
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _isPlaying = true;
    }
}