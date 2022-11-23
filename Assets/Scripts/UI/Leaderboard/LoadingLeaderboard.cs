using UnityEngine;

public class LoadingLeaderboard : MonoBehaviour
{
    [SerializeField] private YnadexSDK _ynadexSDK;

    private FillingCurrentPlayerData _fillingCurrentPlayerData;
    private FillingPlayerData[] _fillingPlayerDatas;
    private LeaderboardPlayer[] _players;

    private void Start()
    {
        _fillingCurrentPlayerData = GetComponentInChildren<FillingCurrentPlayerData>();
        _fillingPlayerDatas = GetComponentsInChildren<FillingPlayerData>();
    }

    private void Update()
    {
        if (_ynadexSDK.IsLeaderboardLoaded)
        {
            _players = _ynadexSDK.Players;
            _fillingCurrentPlayerData.Set(_ynadexSDK.CurrentPlayer);

            for (int i = 0; i < _players.Length; i++)
            {
                foreach (var playerData in _fillingPlayerDatas)
                {
                    playerData.Set(_players[i]);
                }

                if (i >= _players.Length - 1)
                    enabled = false;
            }
        }
    }
}
