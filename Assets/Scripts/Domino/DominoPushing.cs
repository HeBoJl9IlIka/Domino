using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DominoPushing : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Push()
    {
        _rigidbody.AddRelativeForce(Vector3.left * _speed * Time.deltaTime, ForceMode.VelocityChange);
        _speed = 0;
    }
}
