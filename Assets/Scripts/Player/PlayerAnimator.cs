using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimator : MonoBehaviour
{
    private const string IsMoving = "IsMoving";
    private const string Kick = "Kick";

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

    public void Slam()
    {
        _animator.SetTrigger(Kick);
    }
}
