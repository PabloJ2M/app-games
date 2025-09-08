using UnityEngine;

public class Run : BodyBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update() => _rigidbody.linearVelocityX = _speed;
}