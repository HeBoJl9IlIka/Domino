using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;

public class YandexAds : MonoBehaviour
{
    [SerializeField] private RobotSpawner _robotSpawner;

    public event UnityAction Shows;
    public event UnityAction Showed;

    public void Show()
    {
        VideoAd.Show(OnOpened, OnRewarded, OnClosed);
    }

    private void OnOpened()
    {
        Shows?.Invoke();
    }
    
    private void OnRewarded()
    {
        _robotSpawner.enabled = true;
    }
    
    private void OnClosed()
    {
        Showed?.Invoke();
    }
}
