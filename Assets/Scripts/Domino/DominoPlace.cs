using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DominoPlace : MonoBehaviour
{
    [SerializeField] private Thief _thief;

    private PointDomino[] _points;

    public Transform Target { get; private set; }

    public event UnityAction AllShowed;

    private void Awake()
    {
        _points = GetComponentsInChildren<PointDomino>();
    }

    private void Start()
    {
        ShowTarget();
    }

    private void OnEnable()
    {
        foreach (PointDomino pointDomino in _points)
            pointDomino.Showed += OnShowed;

        _thief.Stolen += OnStolen;
    }

    private void OnDisable()
    {
        foreach (PointDomino pointDomino in _points)
            pointDomino.Showed -= OnShowed;

        _thief.Stolen -= OnStolen;
    }

    public void ShowDomino()
    {
        PointDomino point = _points.FirstOrDefault(point => point.IsIndicates == true);

        if (point != null)
            point.ShowDomino();
    }

    private void ShowTarget()
    {
        PointDomino point = _points.FirstOrDefault(point => point.IsActive == false);

        if (point != null)
        {
            Target = point.transform;
            point.ShowPointer();
        }
        else
        {
            AllShowed?.Invoke();
        }
    }

    private void OnShowed(int price)
    {
        ShowTarget();
    }

    private void OnStolen()
    {
        foreach (PointDomino pointDomino in _points)
            pointDomino.HidePointer();

        ShowTarget();
    }
}
