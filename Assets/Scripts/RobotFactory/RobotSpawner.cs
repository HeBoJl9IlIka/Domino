using System.Linq;
using UnityEngine;

public class RobotSpawner : MonoBehaviour
{
    [SerializeField] private Transform _pointSpawn;

    private Robot[] _robots;

    public bool IsFull => _robots.FirstOrDefault(robot => robot.gameObject.activeSelf == false) != null;

    private void Awake()
    {
        _robots = GetComponentsInChildren<Robot>();

        foreach (Robot robot in _robots)
            robot.gameObject.SetActive(false);

        enabled = false;
    }

    private void OnEnable()
    {
        var robot = _robots.FirstOrDefault(robot => robot.gameObject.activeSelf == false);

        if (robot != null)
        {
            robot.gameObject.SetActive(true);
            robot.transform.position = _pointSpawn.position;
        }

        enabled = false;
    }
}
