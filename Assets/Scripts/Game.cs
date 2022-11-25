using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    private YandexLeaderboardLoading _leaderboardLoading;
    private YandexSavingPlayerScore _savingPlayerScore;

    public event UnityAction<string> Action;

    private void Start()
    {
        Action?.Invoke("Game start");
        _leaderboardLoading = GetComponent<YandexLeaderboardLoading>();
        _savingPlayerScore = GetComponent<YandexSavingPlayerScore>();
    }

    private void Update()
    {
        if (YandexGamesSdk.IsInitialized == false)
            return;

        Action?.Invoke("Game: yandexSDK is init");
        _leaderboardLoading.enabled = true;
        _savingPlayerScore.enabled = true;
        enabled = false;
    }
}
