using UnityEngine;

public class ViewingLeaderboard : MonoBehaviour
{
    [SerializeField] private YandexLeaderboardLoading _yandexLeaderboardLoading;

    private FillingPlayerData[] _fillingPlayerDatas;
    private LeaderboardPlayer[] _players;

    private void OnEnable()
    {
        _fillingPlayerDatas = GetComponentsInChildren<FillingPlayerData>();

        _players = _yandexLeaderboardLoading.Players;

        for (int i = 0; i < _players.Length; i++)
        {
            if(_fillingPlayerDatas[i] != null)
                _fillingPlayerDatas[i].Set(_players[i]);
        }

        enabled = false;
    }
}
