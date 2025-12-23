using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBasic<GameManager>
{
    [SerializeField] private AnimationCurve _acceleration;
    [SerializeField] private Vector2 _clampSpeed;
    [SerializeField] private float _time;
    [SerializeField] private bool _startDisabled;

    public UnityEvent<float> onSpeedUpdated;
    public UnityEvent onCompleteGame;

    private float _speed, _currentSpeed;

    public float Speed { get; private set; }
    public bool IsEnabled { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if (_time != 0) _speed = 1f / _time;
        if (!_startDisabled) IsEnabled = true;
    }
    private void Update()
    {
        onSpeedUpdated.Invoke(Speed);
        if (!IsEnabled || _currentSpeed >= 1f) return;

        _currentSpeed = Mathf.Clamp01(_currentSpeed + Time.deltaTime * _speed);
        Speed = Mathf.Lerp(_clampSpeed.x, _clampSpeed.y, _acceleration.Evaluate(_currentSpeed));
    }
    
    public void Enable() => IsEnabled = true;
    public void Disable()
    {
        Speed = 0f;
        IsEnabled = false;
        onCompleteGame.Invoke();
    }
}