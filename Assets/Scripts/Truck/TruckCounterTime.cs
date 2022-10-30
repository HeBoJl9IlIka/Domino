using UnityEngine;

[RequireComponent(typeof(Truck))]
[RequireComponent(typeof(TruckMovementAnimation))]
public class TruckCounterTime : MonoBehaviour
{
    private Truck _truck;
    private TruckMovementAnimation _truckMovement;
    private float _lastTimeAction;
    private float _delay;

    private void Start()
    {
        _truck = GetComponent<Truck>();
    }

    private void Update()
    {
        _lastTimeAction += Time.deltaTime;

        if (_lastTimeAction >= _delay)
        {
            _truck.Act();
        }
    }
}
