using UnityEngine;

[RequireComponent(typeof(RobotTakingOre))]
[RequireComponent(typeof(RobotDropOre))]
public class Robot : MonoBehaviour
{
    [SerializeField] private GameObject _ore;

    private RobotTakingOre _takingOre;
    private RobotDropOre _dropedOre;
    private Vector3 _defaultPosition;

    public bool IsFull { get; private set; }

    private void Awake()
    {
        _takingOre = GetComponent<RobotTakingOre>();
        _dropedOre = GetComponent<RobotDropOre>();
        _defaultPosition = new Vector3(1.5f, 0.5f, 0);
    }

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
