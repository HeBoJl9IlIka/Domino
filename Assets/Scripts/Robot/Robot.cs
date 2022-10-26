using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private GameObject _ore;

    [SerializeField] private RobotTakingOre _takingOre;
    [SerializeField] private RobotDropOre _dropedOre;

    public bool IsFull { get; private set; }

    private void OnEnable()
    {
        _takingOre.Taked += OnTaked;
        _dropedOre.Droped += OnDroped;
    }

    private void OnDisable()
    {
        _takingOre.Taked -= OnTaked;
        _dropedOre.Droped += OnDroped;
    }

    private void OnTaked()
    {
        IsFull = true;
        _ore.SetActive(true);
    }

    private void OnDroped()
    {
        IsFull = false;
        _ore.SetActive(false);
    }
}
