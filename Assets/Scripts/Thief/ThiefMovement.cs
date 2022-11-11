using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ThiefMovement : MonoBehaviour
{
    private const float MaxSpeed = 10;

    private NavMeshAgent _agent;
    private float _defaultSpeed;

    public bool IsEscaped => _agent.hasPath == false;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _defaultSpeed = _agent.speed;
    }

    public void Move(Transform transform)
    {
        _agent.destination = transform.position;
    }

    public void SpeedUp()
    {
        _agent.speed = MaxSpeed;
    }

    public void SpeedDown()
    {
        _agent.speed = _defaultSpeed;
    }
}
