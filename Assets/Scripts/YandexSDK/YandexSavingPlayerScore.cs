using Agava.YandexGames;
using UnityEngine;

public class YandexSavingPlayerScore : MonoBehaviour
{
    private const string LeaderboardName = "dominoLeaderboard";

    [SerializeField] private PlayerWallet _playerWallet;

    private void OnEnable()
    {
        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result == null)
            {
                Leaderboard.SetScore(LeaderboardName, _playerWallet.Money);
            }
            else
            {
                if (result.score < _playerWallet.Money)
                    Leaderboard.SetScore(LeaderboardName, _playerWallet.Money);
            }
        });
    }
}
