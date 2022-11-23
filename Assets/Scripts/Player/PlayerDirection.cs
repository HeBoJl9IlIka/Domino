using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    private void Update()
    {
        if (_joystick.IsPressed)
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(_joystick.Direction.x, _joystick.Direction.y) * Mathf.Rad2Deg, 0);
        else
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg, 0);
    }
}
