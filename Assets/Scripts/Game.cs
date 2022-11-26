using UnityEngine;

public class Game : MonoBehaviour
{
    private YandexInitialization _yandexInitialization;
    private YandexLeaderboardLoading _leaderboardLoading;
    private YandexSavingPlayerScore _savingPlayerScore;

    //public event UnityAction<string> Action;

    private void Awake()
    {
        //Action?.Invoke("Game start");
        _yandexInitialization = GetComponent<YandexInitialization>();
        _leaderboardLoading = GetComponent<YandexLeaderboardLoading>();
        _savingPlayerScore = GetComponent<YandexSavingPlayerScore>();
    }

    //private void Update()
    //{
    //    if (YandexGamesSdk.IsInitialized == false)
    //        return;

    //    //Action?.Invoke("Game: yandexSDK is init");
    //    _leaderboardLoading.enabled = true;
    //    _savingPlayerScore.enabled = true;
    //    enabled = false;
    //}

    private void OnEnable()
    {
        _yandexInitialization.PlayerAuthorizated += OnPlayerAuthorizated;
    }

    private void OnDisable()
    {
        _yandexInitialization.PlayerAuthorizated -= OnPlayerAuthorizated;
    }

    private void OnPlayerAuthorizated()
    {
        _leaderboardLoading.enabled = true;
        _savingPlayerScore.enabled = true;
    }
}
