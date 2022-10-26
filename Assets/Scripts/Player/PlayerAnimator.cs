using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimator : MonoBehaviour
{
    private const string IsMoving = "IsMoving";

    [SerializeField] private Joystick _joystick;
    [SerializeField] private Animator _animator;

    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _animator.SetBool(IsMoving, _playerMovement.IsMoving & _joystick.IsPressed);
    }
}
