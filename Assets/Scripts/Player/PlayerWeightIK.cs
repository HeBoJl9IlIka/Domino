using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(PlayerDropDomino))]
[RequireComponent(typeof(PlayerTakingDomino))]
public class PlayerWeightIK : MonoBehaviour
{
    [SerializeField] private RigBuilder _rigBuilder;
    [SerializeField] private PlayerDropDomino _playerDropDomino;
    [SerializeField] private PlayerTakingDomino _playerTakingDomino;
    
    private void OnEnable()
    {
        _playerDropDomino.Droped += OnDroped;
        _playerTakingDomino.Taked += OnTaked;
    }

    private void OnDisable()
    {
        _playerDropDomino.Droped -= OnDroped;
        _playerTakingDomino.Taked -= OnTaked;
    }

    private void OnDroped()
    {
        _rigBuilder.enabled = false;
    }

    private void OnTaked()
    {
        _rigBuilder.enabled = true;
    }
}
