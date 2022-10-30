using UnityEngine;

public class Truck : MonoBehaviour
{
    private TruckMovement _truckMovement;

    private void Awake()
    {
        _truckMovement = GetComponent<TruckMovement>();
        enabled = true;
    }

    private void OnEnable()
    {
        _truckMovement.enabled = false;
    }
}
