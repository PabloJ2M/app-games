using UnityEngine;

public class FramesPerSecond : MonoBehaviour
{
    [SerializeField] private int _target = 60;

    private void Start() => Application.targetFrameRate = _target;
}