using UnityEngine;

[RequireComponent(typeof(PlayerTakingDomino))]
[RequireComponent(typeof(PlayerDropDomino))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Truck _truck;

    private Domino _domino;
    private PlayerTakingDomino _playerTakingDomino;
    private PlayerDropDomino _playerDropDomino;
    private PlayerAnimator _playerAnimator;

    public bool IsFull { get; private set; }

    private void Awake()
    {
        _domino = GetComponentInChildren<Domino>();
        _playerTakingDomino = GetComponent<PlayerTakingDomino>();
        _playerDropDomino = GetComponent<PlayerDropDomino>();
        _playerAnimator = GetComponent<PlayerAnimator>();

        _domino.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _playerTakingDomino.Taked += OnTaked;
        _playerDropDomino.Droped += OnDroped;
        _truck.Loaded += OnLoaded;
    }

    private void OnDisable()
    {
        _playerTakingDomino.Taked -= OnTaked;
        _playerDropDomino.Droped -= OnDroped;
        _truck.Loaded -= OnLoaded;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
            _playerAnimator.Slam();
    }

    private void OnTaked()
    {
        IsFull = true;
        _domino.gameObject.SetActive(true);
    }

    private void OnDroped()
    {
        IsFull = false;
        _domino.gameObject.SetActive(false);
    }
    
    private void OnLoaded(int arg0)
    {
        IsFull = false;
        _domino.gameObject.SetActive(false);
    }
}
