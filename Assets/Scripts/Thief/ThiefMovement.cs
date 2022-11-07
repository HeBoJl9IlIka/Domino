using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ThiefMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private NavMeshAgent _agent;

    public bool IsEscaped => _agent.hasPath == false;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void Move(Transform transform)
    {
        _agent.destination = transform.position;
    }
}
