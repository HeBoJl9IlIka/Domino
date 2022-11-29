using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private Joystick _joystick;

    private void Update()
    {
        if (_joystick.IsPressed)
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(_joystick.Direction.x, _joystick.Direction.y) * Mathf.Rad2Deg, 0);
        else if ((Input.GetAxis(Horizontal) != 0) || (Input.GetAxis(Vertical) != 0))
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical)) * Mathf.Rad2Deg, 0);
    }
}
