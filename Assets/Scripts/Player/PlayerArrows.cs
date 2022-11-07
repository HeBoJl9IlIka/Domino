using UnityEngine;

public class PlayerArrows : MonoBehaviour
{
    [SerializeField] private Thief _thief;
    [SerializeField] private Truck _truck;
    [SerializeField] private ArrowThiefDirection _arrowThiefDirection;
    [SerializeField] private ArrowTruckDirection _arrowTruckDirection;
 
    private void OnEnable()
    {
        _thief.Enabled += OnEnabledThief;
        _thief.Disabled += OnDisabledThief;
        _truck.Enabled += OnEnabledTruck;
        _truck.Disabled += OnDisabledTruck;
    }

    private void OnDisable()
    {
        _thief.Enabled -= OnEnabledThief;
        _thief.Disabled -= OnDisabledThief;
        _truck.Enabled -= OnEnabledTruck;
        _truck.Disabled -= OnDisabledTruck;
    }

    private void OnEnabledThief()
    {
        _arrowThiefDirection.gameObject.SetActive(true);
    }

    private void OnDisabledThief()
    {
        _arrowThiefDirection.gameObject.SetActive(false);
    }

    private void OnEnabledTruck()
    {
        _arrowTruckDirection.gameObject.SetActive(true);
    }

    private void OnDisabledTruck()
    {
        _arrowTruckDirection.gameObject.SetActive(false);
    }
}
