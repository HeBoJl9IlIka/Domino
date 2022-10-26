using UnityEngine;

[RequireComponent(typeof(PlayerTakingDomino))]
[RequireComponent(typeof(PlayerDropDomino))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _domino;
    [SerializeField] private PlayerTakingDomino _playerTakingDomino;
    [SerializeField] private PlayerDropDomino _playerDropDomino;

    public bool IsFull { get; private set; }

    private void OnEnable()
    {
        _playerTakingDomino.Taked += OnTaked;
        _playerDropDomino.Droped += OnDroped;
    }

    private void OnDisable()
    {
        _playerTakingDomino.Taked -= OnTaked;
        _playerDropDomino.Droped += OnDroped;
    }

    private void OnTaked()
    {
        IsFull = true;
        _domino.SetActive(true);
    }

    private void OnDroped()
    {
        IsFull = false;
        _domino.SetActive(false);
    }
}
