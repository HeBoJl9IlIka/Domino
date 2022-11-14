using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] private DominoPlace _dominoPlace;
    [SerializeField] private ThiefSpawn _thiefSpawn;
    [SerializeField] private TruckSpawnTime _truckSpawnTime;
    [SerializeField] private int _levelReward;

    public event UnityAction<int> Completed;

    private void OnEnable()
    {
        _dominoPlace.AllShowed += OnAllShowed;
    }

    private void OnDisable()
    {
        _dominoPlace.AllShowed -= OnAllShowed;
    }

    private void OnAllShowed()
    {
        _thiefSpawn.gameObject.SetActive(false);
        _truckSpawnTime.gameObject.SetActive(false);
        Completed?.Invoke(_levelReward);
    }
}
