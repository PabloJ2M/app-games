using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class ForceTrail : MonoBehaviour
{
    private TrailRenderer _trail;

    private void Awake() => _trail = GetComponent<TrailRenderer>();
    private void Update()
    {
        
    }
}