using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Robot))]
public class RobotDropOre : MonoBehaviour
{
    private Robot _robot;

    public event UnityAction Droped;

    private void Start()
    {
        _robot = GetComponent<Robot>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out FactoryWarehouse factoryWarehouse))
        {
            if(_robot.IsFull)
                Droped?.Invoke();
        }
    }
}
