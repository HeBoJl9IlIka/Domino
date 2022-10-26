using System;
using System.Collections;
using UnityEngine;

public class OreDumpingState : State
{
    [SerializeField] private RobotMovement _robotMovement;
    [SerializeField] private RobotDropOre _robotDropOre;
    [SerializeField] private Transform _targetPosition;

    public bool IsReady { get; private set; }

    private void Update()
    {
        _robotMovement.Move(_targetPosition);
    }

    private void OnEnable()
    {
        _robotDropOre.Droped += OnDroped;
    }

    private void OnDisable()
    {
        _robotDropOre.Droped -= OnDroped;
    }

    public void Reset()
    {
        IsReady = false;
    }

    private void OnDroped()
    {
        IsReady = true;
    }
}
