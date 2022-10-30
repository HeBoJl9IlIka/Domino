using UnityEngine;

public class TimeSpawnTruck : MonoBehaviour
{
    [SerializeField] private float _delay;

    private Truck _truck;

    private float _lastTimeSpawn;

    private void Update()
    {
        _lastTimeSpawn += Time.deltaTime;
        
        if (_lastTimeSpawn >= _delay)
        {
            _truck.gameObject.SetActive(true);
            _lastTimeSpawn = 0;
        }
    }
}
