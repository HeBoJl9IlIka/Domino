using Agava.YandexGames;
using UnityEngine;
//using UnityEngine.Events;

public class YandexSavingPlayerScore : MonoBehaviour
{
    private const string LeaderboardName = "dominoLeaderboard";

    [SerializeField] private PlayerWallet _playerWallet;

    //public event UnityAction<string> Action;

    private void OnEnable()
    {
        //Action?.Invoke("YandexSavingPlayerScore enable");
        if (_playerWallet.Money == 0)
            return;

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            //Action?.Invoke("YandexSavingPlayerScore: GetPlayerEntry");
            if (result == null)
            {
                Leaderboard.SetScore(LeaderboardName, _playerWallet.Money);
                //Action?.Invoke("YandexSavingPlayerScore: result = null");
            }
            else
            {
                if (result.score < _playerWallet.Money)
                    Leaderboard.SetScore(LeaderboardName, _playerWallet.Money);
                //Action?.Invoke("YandexSavingPlayerScore: result != null");
            }
        });
    }
}
