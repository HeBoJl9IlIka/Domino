using UnityEngine;
using UnityEngine.Events;

public class DominoFactoryWarehouse : MonoBehaviour
{
    [SerializeField] private RobotDropOre[] _robotsDropOre;
    [SerializeField] private PlayerDroppingOre _playerDroppingOre;

    public uint OreCount { get; private set; }

    public event UnityAction<uint> Loaded;

    private void OnEnable()
    {
        foreach (RobotDropOre robot in _robotsDropOre)
        {
            robot.Droped += OnDroped;
        }

        _playerDroppingOre.Droped += OnDroped;
    }

    private void OnDisable()
    {
        foreach (RobotDropOre robot in _robotsDropOre)
        {
            robot.Droped -= OnDroped;
        }

        _playerDroppingOre.Droped -= OnDroped;
    }

    public void RemoveOre(int needAmount)
    {
        OreCount -= (uint)needAmount;
    }

    private void OnDroped()
    {
        ++OreCount;
        Loaded?.Invoke(OreCount);
    }
}
