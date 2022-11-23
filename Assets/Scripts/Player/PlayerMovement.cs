using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    public bool IsMoving => _rigidbody.velocity.magnitude > 0;

    private float _normalizedJoystickSpeedHorizontal => _joystick.Horizontal * _speed * Time.deltaTime;
    private float _normalizedJoystickSpeedVertical => _joystick.Vertical * _speed * Time.deltaTime;
    private float _normalizedKeybordSpeedHorizontal => Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
    private float _normalizedKeybordSpeedVertical => Input.GetAxis("Vertical") * _speed * Time.deltaTime;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_joystick.IsPressed)
            _rigidbody.AddForce(new Vector3(_normalizedJoystickSpeedHorizontal, 0, _normalizedJoystickSpeedVertical), ForceMode.VelocityChange);
        else
            _rigidbody.AddForce(new Vector3(_normalizedKeybordSpeedHorizontal, 0, _normalizedKeybordSpeedVertical), ForceMode.VelocityChange);
    }
}
