using UnityEngine;

public class ThiefSpawn : MonoBehaviour
{
    [SerializeField] private Thief _thief;
    [SerializeField] private GameObject _pointContainer;
    [SerializeField] private float _delaySpawn;

    private ThiefPickDomino _thiefPickDomino;
    private Point[] _points;
    private float _lastTimeSpawn;

    public Point Target => _points[Random.Range(0, _points.Length)];

    private void Awake()
    {
        _points = _pointContainer.GetComponentsInChildren<Point>();
        _thiefPickDomino = _thief.GetComponent<ThiefPickDomino>();
    }

    private void Update()
    {
        if (_thief.gameObject.activeSelf)
            return;

        if (_thief.DominoIsReady == false)
            return;

        _lastTimeSpawn += Time.deltaTime;

        if (_lastTimeSpawn >= _delaySpawn)
        {
            if (Random.Range(0, 1) == 0)
            {
                if (_thiefPickDomino.TryGetActiveDomino(out Domino domino))
                {
                    _thief.gameObject.SetActive(true);
                    _thief.Steal(domino);
                }
            }

            _lastTimeSpawn = 0;
        }
    }
}
