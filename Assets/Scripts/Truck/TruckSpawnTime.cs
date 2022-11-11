using UnityEngine;

public class TruckSpawnTime : MonoBehaviour
{
    [SerializeField] private float _delay;

    private Truck _truck;
    private float _lastSpawnTime;

    private void Start()
    {
        _truck = GetComponentInChildren<Truck>();
        _truck.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(_truck.gameObject.activeSelf == false)
            _lastSpawnTime += Time.deltaTime;

        if (_lastSpawnTime >= _delay)
        {
            _truck.gameObject.SetActive(true);
            _lastSpawnTime = 0;
        }
    }
}
