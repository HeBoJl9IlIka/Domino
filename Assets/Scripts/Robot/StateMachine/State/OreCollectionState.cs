using System.Linq;
using UnityEngine;

public class OreCollectionState : State
{
    [SerializeField] private RobotMovement _robotMovement;
    [SerializeField] private RobotTakingOre _takingOre;
    [SerializeField] private RobotDropOre _dropOre;
    [SerializeField] private Ore[] _ores;

    private Ore _ore;
    private bool _isBusy;

    public bool IsReady { get; private set; }

    private void Update()
    {
        if(_isBusy == false)
            _ore = _ores.FirstOrDefault(ore => ore.gameObject.activeSelf == true);

        if (_ore != null)
        {
            _isBusy = true;
            _robotMovement.Move(_ore.transform);
        }
    }

    private void OnEnable()
    {
        _takingOre.Taked += OnTaked;
        _dropOre.Droped += OnDroped;
    }

    private void OnDisable()
    {
        _takingOre.Taked -= OnTaked;
        _dropOre.Droped -= OnDroped;
    }

    public void Reset()
    {
        IsReady = false;
    }

    private void OnTaked()
    {
        IsReady = true;
    }

    private void OnDroped()
    {
        _isBusy = false;
    }
}
