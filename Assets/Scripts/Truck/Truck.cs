using UnityEngine;

[RequireComponent(typeof(TruckMovementAnimation))]
public class Truck : MonoBehaviour
{
    private TruckMovementAnimation _truckMovement;

    private void Start()
    {
        _truckMovement = GetComponent<TruckMovementAnimation>();
    }

    public void Act()
    {

    }
}
