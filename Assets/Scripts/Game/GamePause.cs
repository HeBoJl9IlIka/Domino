using UnityEngine;

[RequireComponent(typeof(YandexAds))]
public class GamePause : MonoBehaviour
{
    private YandexAds _yandexAds;

    private void Awake()
    {
        _yandexAds = GetComponent<YandexAds>();
    }

    private void OnEnable()
    {
        _yandexAds.Shows += OnShows;
        _yandexAds.Showed += OnShowed;
    }

    private void OnDisable()
    {
        _yandexAds.Shows -= OnShows;
        _yandexAds.Showed -= OnShowed;
    }

    private void OnShows()
    {
        Time.timeScale = 0;
    }
    
    private void OnShowed()
    {
        Time.timeScale = 1;
    }
}
