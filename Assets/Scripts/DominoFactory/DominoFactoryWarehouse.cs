using UnityEngine;
using UnityEngine.Events;

public class DominoFactoryWarehouse : MonoBehaviour
{
    [SerializeField] private RobotDropOre[] _robotsDropOre;
    [SerializeField] private DominoFactoryProduction _factoryProduction;

    public uint OreCount { get; private set; }

    public event UnityAction<uint> Loaded;

    private void OnEnable()
    {
        foreach (RobotDropOre robot in _robotsDropOre)
        {
            robot.Droped += OnDroped;
        }

        _factoryProduction.Produced += OnProduced;
    }

    private void OnDisable()
    {
        foreach (RobotDropOre robot in _robotsDropOre)
        {
            robot.Droped -= OnDroped;
        }

        _factoryProduction.Produced -= OnProduced;
    }

    private void OnDroped()
    {
        ++OreCount;
        Loaded?.Invoke(OreCount);
    }

    private void OnProduced(int needAmount)
    {
        OreCount -= (uint)needAmount;
    }
}
