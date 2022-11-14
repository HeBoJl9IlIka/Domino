using UnityEngine;

public class Reward : MonoBehaviour
{
    private const int Multiplier = 100;

    [SerializeField] private DominoPlace _containerDomino;
    [SerializeField] private Truck _truck;
    [SerializeField] private AnimationMoneyMovement[] _moneys;

    private PointDomino[] _pointsDomino;

    private void Awake()
    {
        _pointsDomino = _containerDomino.GetComponentsInChildren<PointDomino>();
    }

    private void OnEnable()
    {
        foreach (PointDomino point in _pointsDomino)
            point.Showed += OnShowed;

        _truck.Loaded += OnShowed;
    }

    private void OnDisable()
    {
        foreach (PointDomino point in _pointsDomino)
            point.Showed -= OnShowed;

        _truck.Loaded -= OnShowed;
    }

    private void OnShowed(int price)
    {
        int amountMoney = price / Multiplier;

        if (amountMoney > _moneys.Length)
            amountMoney = _moneys.Length;

        for (int i = 0; i < amountMoney; i++)
        {
            _moneys[i].gameObject.SetActive(true);
        }
    }
}
