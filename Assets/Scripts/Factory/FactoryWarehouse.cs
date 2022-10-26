using UnityEngine;

public class FactoryWarehouse : MonoBehaviour
{
    [SerializeField] private RobotDropOre[] _robotsDropOre;
    [SerializeField] private FactoryProduction _factoryProduction;

    public uint OreCount { get; private set; }

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
    }

    private void OnProduced(int needAmount)
    {
        OreCount -= (uint)needAmount;
    }
}
