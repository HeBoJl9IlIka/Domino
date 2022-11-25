using Agava.YandexGames;
using UnityEngine;

public class Game : MonoBehaviour
{
    private YandexLeaderboardLoading _leaderboardLoading;
    private YandexSavingPlayerScore _savingPlayerScore;

    private void Start()
    {
        _leaderboardLoading = GetComponent<YandexLeaderboardLoading>();
        _savingPlayerScore = GetComponent<YandexSavingPlayerScore>();
    }

    private void Update()
    {
        if (YandexGamesSdk.IsInitialized == false)
            return;

        _leaderboardLoading.enabled = true;
        _savingPlayerScore.enabled = true;
        enabled = false;
    }
}
