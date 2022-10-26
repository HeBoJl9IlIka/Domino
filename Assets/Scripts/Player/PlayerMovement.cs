using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    public bool IsMoving => _rigidbody.velocity.magnitude > 0;

    private float _normalizedSpeedHorizontal => _joystick.Horizontal * _speed * Time.deltaTime;
    private float _normalizedSpeedVertical => _joystick.Vertical * _speed * Time.deltaTime;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_joystick.IsPressed)
            _rigidbody.AddForce(new Vector3(_normalizedSpeedHorizontal, 0, _normalizedSpeedVertical), ForceMode.VelocityChange);
    }
}
