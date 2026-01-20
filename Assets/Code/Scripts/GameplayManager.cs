using UnityEngine;
using UnityEngine.Events;
using Unity.Mathematics;

public class GameplayManager : SingletonBasic<GameplayManager>
{
    [SerializeField] private AnimationCurve _acceleration;
    [SerializeField] private float2 _clampSpeed = new float2(1f, 1f);
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

        _currentSpeed = math.clamp(_currentSpeed + Time.deltaTime * _speed, 0f, 1f);
        Speed = math.lerp(_clampSpeed.x, _clampSpeed.y, _acceleration.Evaluate(_currentSpeed));
    }
    
    public void ResetGame()
    {
        IsEnabled = true;
        Speed = _currentSpeed = 0;
    }
    public void Enable()
    {
        IsEnabled = true;
        _currentSpeed = 0;
    }
    public void Disable()
    {
        Speed = 0f;
        IsEnabled = false;
        onCompleteGame.Invoke();
    }
}