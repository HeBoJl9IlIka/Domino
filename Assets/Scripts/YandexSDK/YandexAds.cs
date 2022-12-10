using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;

public class YandexAds : MonoBehaviour
{
    private const float _delay = 3.2f;

    [SerializeField] private RobotSpawner _robotSpawner;
    [SerializeField] private LastDomino _lastDomino;

    public bool IsShows { get; private set; }

    public event UnityAction Shows;
    public event UnityAction Showed;

    private void OnEnable()
    {
        _lastDomino.Finished += OnFinished;
    }

    private void OnDisable()
    {

        _lastDomino.Finished -= OnFinished;
    }

    public void ShowRewarded()
    {
        VideoAd.Show(OnOpened, OnRewarded, OnClosed);
    }

    public void OnFinished()
    {
        Invoke(nameof(ShowInterstitial), _delay);
    }

    public void OnOpened()
    {
        IsShows = true;
        Shows?.Invoke();
    }
    
    private void OnRewarded()
    {
        _robotSpawner.enabled = true;
    }
    
    public void OnClosed()
    {
        IsShows = false;
        Showed?.Invoke();
    }
    
    private void OnClosed(bool onClose)
    {
        IsShows = false;
        Showed?.Invoke();
    }

    private void ShowInterstitial()
    {
        InterstitialAd.Show(OnOpened, OnClosed);
    }
}
