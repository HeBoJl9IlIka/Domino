using UnityEngine;

public class ViewingLeaderboard : MonoBehaviour
{
    [SerializeField] private YandexLeaderboardLoading _yandexLeaderboardLoading;

    private FillingPlayerData[] _fillingPlayerDatas;
    private LeaderboardPlayer[] _players;

    private void Start()
    {
        _fillingPlayerDatas = GetComponentsInChildren<FillingPlayerData>();
    }

    private void Update()
    {
        if (_yandexLeaderboardLoading.IsLeaderboardLoaded)
        {
            _players = _yandexLeaderboardLoading.Players;

            for (int i = 0; i < _players.Length; i++)
            {
                foreach (var playerData in _fillingPlayerDatas)
                    playerData.Set(_players[i]);

                if (i >= _players.Length - 1)
                    enabled = false;
            }
        }
    }
}
