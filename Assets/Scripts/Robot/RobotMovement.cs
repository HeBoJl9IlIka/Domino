using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RobotMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void Move(Transform transform)
    {
        _agent.destination = transform.position;
    }
}
