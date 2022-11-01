using UnityEngine;

public class TruckSpawnTime : MonoBehaviour
{
    private const float Delay = 30;

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

        if (_lastSpawnTime >= Delay)
        {
            _truck.gameObject.SetActive(true);
            _lastSpawnTime = 0;
        }
    }
}
