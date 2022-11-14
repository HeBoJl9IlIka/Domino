using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private const int MoneyStep = 10;

    [SerializeField] private DominoPlace _containerDomino;
    [SerializeField] private Truck _truck;
    [SerializeField] private Level _level;

    private PointDomino[] _dominos;
    private int _money;

    public event UnityAction<int> Changed;

    private void Awake()
    {
        _dominos = _containerDomino.GetComponentsInChildren<PointDomino>();
    }

    private void Start()
    {
        Changed?.Invoke(_money);
    }

    private void OnEnable()
    {
        foreach (PointDomino domino in _dominos)
            domino.Showed += OnShowed;

        _truck.Loaded += OnLoaded;
        _level.Completed += OnShowed;
    }

    private void OnDisable()
    {
        foreach (PointDomino domino in _dominos)
            domino.Showed -= OnShowed;

        _truck.Loaded -= OnLoaded;
        _level.Completed -= OnShowed;
    }

    public bool TryBuy(int price)
    {
        bool isBought = false;

        if (_money >= price)
        {
            _money -= price;
            isBought = true;
            Changed?.Invoke(_money);
        }

        return isBought;
    }

    private void OnShowed(int price)
    {
        StartCoroutine(Add(price));
    }
    
    private void OnLoaded(int price)
    {
        StartCoroutine(Add(price));
    }

    private IEnumerator Add(int money)
    {
        for (int i = 0; i < money / MoneyStep; i++)
        {
            _money += MoneyStep;
            Changed?.Invoke(_money);
            yield return null;
        }
    }

    private void Remove(int money)
    {
        _money -= money;
        Changed?.Invoke(_money);
    }
}
