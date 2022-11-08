using UnityEngine;

public class ArrowTruckDirection : MonoBehaviour
{
    [SerializeField] private Truck _truck;

    private void Update()
    {
        Vector3 targetPostition = new Vector3(_truck.transform.position.x, this.transform.position.y, _truck.transform.position.z);
        this.transform.LookAt(targetPostition);
    }
}
