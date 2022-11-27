using UnityEngine;

[RequireComponent(typeof(YandexInitialization))]
[RequireComponent(typeof(YandexSavingPlayerScore))]
[RequireComponent(typeof(YandexLeaderboardLoading))]
[RequireComponent(typeof(LoadingScene))]
[RequireComponent(typeof(Data))]
public class Game : MonoBehaviour
{
    private YandexInitialization _yandexInitialization;
    private YandexSavingPlayerScore _savingPlayerScore;
    private YandexLeaderboardLoading _leaderboardLoading;
    private LoadingScene _loadingScene;
    private Data _data;

    private void Awake()
    {
        _yandexInitialization = GetComponent<YandexInitialization>();
        _savingPlayerScore = GetComponent<YandexSavingPlayerScore>();
        _leaderboardLoading = GetComponent<YandexLeaderboardLoading>();
        _loadingScene = GetComponent<LoadingScene>();
        _data = GetComponent<Data>();
    }

    private void Start()
    {
        if (_data.LastOpeningLevel != _loadingScene.CurrentScene)
            _loadingScene.Open(_data.LastOpeningLevel);
    }

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
        _savingPlayerScore.enabled = true;
        _leaderboardLoading.enabled = true;
    }
}
