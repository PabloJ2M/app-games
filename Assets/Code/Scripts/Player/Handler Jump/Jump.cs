using UnityEngine;

public class Jump : BodyBehaviour
{
    [SerializeField] protected float _force;

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
    }
}