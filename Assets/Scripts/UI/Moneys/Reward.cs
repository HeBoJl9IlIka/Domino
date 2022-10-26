using UnityEngine;

public class Reward : MonoBehaviour
{
    private const int Multiplier = 5;

    [SerializeField] private AnimationMoneyMovement[] _moneys;
    [SerializeField] private PointDomino[] _pointsDomino;

    private void OnEnable()
    {
        foreach (PointDomino point in _pointsDomino)
        {
            point.Showed += OnShowed; 
        }
    }

    private void OnDisable()
    {
        foreach (PointDomino point in _pointsDomino)
        {
            point.Showed -= OnShowed;
        }
    }

    private void OnShowed(int price, int moneySpawnCount)
    {
        int amountMoney = moneySpawnCount / Multiplier;

        if (amountMoney > _moneys.Length)
            amountMoney = _moneys.Length;

        for (int i = 0; i < amountMoney; i++)
        {
            _moneys[i].gameObject.SetActive(true);
        }
    }
}
