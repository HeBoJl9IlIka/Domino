using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private ParticleSystem _dust;

    private void Update()
    {
        if (_playerMovement.IsMoving)
            _dust.Play();
        else
            _dust.Pause();
    }
}
