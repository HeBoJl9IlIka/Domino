using UnityEngine;

[RequireComponent(typeof(PlayerTakingDomino))]
[RequireComponent(typeof(PlayerDropDomino))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Truck _truck;

    private Domino _domino;
    private Ore _ore;
    private PlayerTakingDomino _playerTakingDomino;
    private PlayerDropDomino _playerDropDomino;
    private PlayerTakingOre _playerTakingOre;
    private PlayerDroppingOre _playerDroppingOre;
    private PlayerAnimator _playerAnimator;

    public bool IsFull { get; private set; }

    private void Awake()
    {
        _domino = GetComponentInChildren<Domino>();
        _ore = GetComponentInChildren<Ore>();
        _playerTakingDomino = GetComponent<PlayerTakingDomino>();
        _playerDropDomino = GetComponent<PlayerDropDomino>();
        _playerTakingOre = GetComponent<PlayerTakingOre>();
        _playerDroppingOre = GetComponent<PlayerDroppingOre>();
        _playerAnimator = GetComponent<PlayerAnimator>();

        _domino.gameObject.SetActive(false);
        _ore.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _playerTakingDomino.Taked += OnTakedDomino;
        _playerDropDomino.Droped += OnDropedDomino;
        _playerTakingOre.Taked += OnTakedOre;
        _playerDroppingOre.Droped += OnDropedOre;
        _truck.Loaded += OnLoaded;
    }

    private void OnDisable()
    {
        _playerTakingDomino.Taked -= OnTakedDomino;
        _playerDropDomino.Droped -= OnDropedDomino;
        _playerTakingOre.Taked -= OnTakedOre;
        _playerDroppingOre.Droped -= OnDropedOre;
        _truck.Loaded -= OnLoaded;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
            _playerAnimator.Slam();
    }

    private void OnTakedDomino()
    {
        IsFull = true;
        _domino.gameObject.SetActive(true);
    }

    private void OnDropedDomino()
    {
        IsFull = false;
        _domino.gameObject.SetActive(false);
    }
    
    private void OnTakedOre()
    {
        IsFull = true;
        _ore.gameObject.SetActive(true);
    }

    private void OnDropedOre()
    {
        IsFull = false;
        _ore.gameObject.SetActive(false);
    }
    
    private void OnLoaded(int arg0)
    {
        IsFull = false;
        _domino.gameObject.SetActive(false);
    }
}
