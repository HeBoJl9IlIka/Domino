using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Robot))]
public class RobotTakingOre : MonoBehaviour
{
    private Robot _robot;

    public event UnityAction Taked;

    private void Start()
    {
        _robot = GetComponent<Robot>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out OreAnimator ore))
        {
            if (_robot.IsFull)
                return;

            Taked?.Invoke();
            ore.gameObject.SetActive(false);
            ore.Reset();
        }
    }
}
