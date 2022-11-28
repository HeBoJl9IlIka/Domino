using Agava.YandexGames;
using UnityEngine;

public class YandexAds : MonoBehaviour
{
    [SerializeField] private RobotSpawner _robotSpawner;

    public void Show()
    {
        VideoAd.Show(null, OnRewarded);
    }

    private void OnRewarded()
    {
        _robotSpawner.enabled = true;
    }
}
