using UnityEngine;

public class UIScoreByDistance : UIScore
{
    [SerializeField] private float _distancePerPoint;
    private float _traveled;

    private void Add() => Add(1);

    public void AddConstant(float amount) => AddDistance(amount * Time.deltaTime);
    public void AddDistance(float amount) => Math.Loop(ref _traveled, amount, _distancePerPoint, Add);
}