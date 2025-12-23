using UnityEngine;
using UnityEngine.Splines;

public class JumpAlongSpline : Jump
{
    [SerializeField] private SplineContainer _spline;
    [SerializeField] private AnimationCurve _curve;
    private bool _isJumping;
    private float _time;

    protected override void Awake()
    {
        base.Awake();
        _transform.position = _spline.EvaluatePosition(0);
    }
    protected override void HandleFirstInteraction()
    {
        if (_manager.IsEnabled) return;
        _manager?.Enable();
    }

    public override void InteractTrigger()
    {
        if (_isJumping && _time < 9.5f) return;
        _isJumping = true;
        _time = 0;
    }
    private void Update()
    {
        if (!_isJumping) return;

        _time = Mathf.MoveTowards(_time, 1f, _manager.Speed * _force * Time.deltaTime);

        float time = _curve.Evaluate(_time);
        float target = _spline.EvaluatePosition(time).y;

        _transform.PositionY(target);

        if (_time < 1) return;
        _isJumping = false;
        _time = 0;
    }
}