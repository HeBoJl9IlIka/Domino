using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private int MaxMoney = 5000;
    private const int SmallStep = 10;
    private const int BigStep = 500;

    [SerializeField] private DominoPlace _containerDomino;
    [SerializeField] private Truck _truck;
    [SerializeField] private Level _level;
    [SerializeField] private Data _data;

    private PointDomino[] _dominos;
    private int _money;

    public int Money => _money;

    public event UnityAction<int> Changed;

    private void Awake()
    {
        _dominos = _containerDomino.GetComponentsInChildren<PointDomino>();
    }

    private void Start()
    {
        _money = _data.AmountMoney;
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

    public void Set(int money)
    {
        _money = money;
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
        int moneyStep = SmallStep;

        if (money >= MaxMoney)
            moneyStep = BigStep;

        for (int i = 0; i < money / moneyStep; i++)
        {
            _money += moneyStep;
            yield return null;
            Changed?.Invoke(_money);
        }
    }
}
