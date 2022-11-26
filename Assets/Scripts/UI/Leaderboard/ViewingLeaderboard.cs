using UnityEngine;
//using UnityEngine.Events;

public class ViewingLeaderboard : MonoBehaviour
{
    [SerializeField] private YandexLeaderboardLoading _yandexLeaderboardLoading;

    private FillingPlayerData[] _fillingPlayerDatas;
    private LeaderboardPlayer[] _players;

    //public event UnityAction<string> Action;

    private void OnEnable()
    {
        _fillingPlayerDatas = GetComponentsInChildren<FillingPlayerData>();

        //Action?.Invoke("ViewingLeaderboard: _yandexLeaderboardLoading.IsLeaderboardLoaded = true");
        _players = _yandexLeaderboardLoading.Players;
        //Action?.Invoke("ViewingLeaderboard: _players.Count = " + _players.Length); 
        for (int i = 0; i < _players.Length; i++)
        {
            if(_fillingPlayerDatas[i] != null)
                _fillingPlayerDatas[i].Set(_players[i]);
            //Action?.Invoke("ViewingLeaderboard: playerData.Set - _player.Name = " + _players[i].Name);
        }

        enabled = false;
    }
}
