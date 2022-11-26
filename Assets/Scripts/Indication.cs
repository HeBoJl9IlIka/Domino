using TMPro;
using UnityEngine;

public class Indication : MonoBehaviour
{
    [SerializeField] private YandexInitialization _yandexInitialization;
    [SerializeField] private YandexLeaderboardLoading _yandexLeaderboardLoading;
    [SerializeField] private YandexSavingPlayerScore _yandexSavingPlayerScore;
    [SerializeField] private ViewingLeaderboard _viewingLeaderboard;
    [SerializeField] private Game _game;
    [SerializeField] private TMP_Text _console;

    private void OnEnable()
    {
        //_yandexInitialization.Action += OnAction;
        //_yandexLeaderboardLoading.Action += OnAction;
        //_yandexSavingPlayerScore.Action += OnAction;
        //_viewingLeaderboard.Action += OnAction;
        //_game.Action += OnAction;
    }

    private void OnDisable()
    {
        //_yandexInitialization.Action -= OnAction;
        //_yandexLeaderboardLoading.Action -= OnAction;
        //_yandexSavingPlayerScore.Action -= OnAction;
        //_viewingLeaderboard.Action -= OnAction;
        //_game.Action -= OnAction;
    }

    private void OnAction(string text)
    {
        _console.text += "\n" + text;
    }
}
