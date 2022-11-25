using UnityEngine;
using UnityEngine.Events;

public class ViewingLeaderboard : MonoBehaviour
{
    [SerializeField] private YandexLeaderboardLoading _yandexLeaderboardLoading;

    private FillingPlayerData[] _fillingPlayerDatas;
    private LeaderboardPlayer[] _players;

    public event UnityAction<string> Action;

    private void Start()
    {
        Action?.Invoke("ViewingLeaderboard start");
        _fillingPlayerDatas = GetComponentsInChildren<FillingPlayerData>();
    }

    private void Update()
    {
        if (_yandexLeaderboardLoading.IsLeaderboardLoaded)
        {
            Action?.Invoke("ViewingLeaderboard: _yandexLeaderboardLoading.IsLeaderboardLoaded = true");
            _players = _yandexLeaderboardLoading.Players;
            Action?.Invoke("ViewingLeaderboard: _players.Count = " + _players.Length); 
            for (int i = 0; i < _players.Length; i++)
            {
                foreach (var playerData in _fillingPlayerDatas)
                    playerData.Set(_players[i]);
                Action?.Invoke("ViewingLeaderboard: playerData.Set - _player.Name = " + _players[i].Name);
                if (i >= _players.Length - 1)
                { 
                    Action?.Invoke("ViewingLeaderboard disable");
                    enabled = false;
                }
            }
        }
    }
}
