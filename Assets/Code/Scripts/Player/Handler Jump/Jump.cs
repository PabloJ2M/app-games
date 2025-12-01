using UnityEngine;
using UnityEngine.Events;

public class Jump : BodyBehaviour
{
    [SerializeField] protected float _force;
    [SerializeField] private UnityEvent _onJump;

    protected override void Awake()
    {
        base.Awake();
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    public override void InteractTrigger()
    {
        if (!enabled) return;
        base.InteractTrigger();
        
        _rigidbody.linearVelocityY = _force;
        if (_onJump.GetPersistentEventCount() != 0) _onJump.Invoke();
    }
}