using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    private void Update()
    {
        if (_playerMovement.IsMoving == false)
            return;

        transform.position = new Vector3(_playerMovement.transform.position.x, 0, _playerMovement.transform.position.z);
    }
}
