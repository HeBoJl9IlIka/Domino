using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private const float _cutSpeed = 250;
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private float _defaultSpeed;

    public bool IsMoving => _rigidbody.velocity.magnitude > 0;

    private float _normalizedJoystickSpeedHorizontal => _joystick.Horizontal * _speed * Time.deltaTime;
    private float _normalizedJoystickSpeedVertical => _joystick.Vertical * _speed * Time.deltaTime;
    private float _normalizedKeybordSpeedHorizontal => Input.GetAxis(Horizontal) * _speed * Time.deltaTime;
    private float _normalizedKeybordSpeedVertical => Input.GetAxis(Vertical) * _speed * Time.deltaTime;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _defaultSpeed = _speed;
    }

    private void Update()
    {
        if (_joystick.IsPressed)
        {
            _speed = _defaultSpeed;
            _rigidbody.AddForce(new Vector3(_normalizedJoystickSpeedHorizontal, 0, _normalizedJoystickSpeedVertical), ForceMode.VelocityChange);
        }
        else if((Input.GetAxis(Horizontal) != 0) || (Input.GetAxis(Vertical) != 0))
        {
            _rigidbody.AddForce(new Vector3(_normalizedKeybordSpeedHorizontal, 0, _normalizedKeybordSpeedVertical), ForceMode.VelocityChange);

            _speed = (Input.GetAxis(Horizontal) != 0) && (Input.GetAxis(Vertical) != 0) ? _cutSpeed : _defaultSpeed;
        }
    }
}
