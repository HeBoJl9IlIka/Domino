using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private const int MoneyStep = 2;

    [SerializeField] PointDomino[] _dominos;

    private int _money;

    public event UnityAction<int> Changed;

    private void Start()
    {
        _money = 41290;
        Changed?.Invoke(_money);
    }

    private void OnEnable()
    {
        foreach (PointDomino domino in _dominos)
        {
            domino.Showed += OnShowed;
        }
    }

    private void OnDisable()
    {
        foreach (PointDomino domino in _dominos)
        {
            domino.Showed -= OnShowed;
        }
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

    private void OnShowed(int price, int moneySpawnCount)
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
