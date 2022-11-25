using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class YandexLeaderboardLoading : MonoBehaviour
{
    private static List<LeaderboardPlayer> _players;

    private const int MaxAmount = 6;
    private const string Anonymous = "Anonymous";
    private const string LeaderboardName = "dominoLeaderboard";

    private int _currentAmount;

    public LeaderboardPlayer[] Players => _players.ToArray();
    public bool IsLeaderboardLoaded => _currentAmount >= MaxAmount;

    public event UnityAction<string> Action;

    private void OnEnable()
    {
        Action?.Invoke("YandexloadLeader enable");

        if (_players == null)
        {
            Action?.Invoke("YandexloadLeader: _players = null");
            _players = new List<LeaderboardPlayer>();
        }
        else
        {
            Action?.Invoke("YandexloadLeader: _players != null");
        }

        Leaderboard.GetEntries(LeaderboardName, (result) =>
        {
            Action?.Invoke("YandexloadLeader: GetEntries");
            foreach (var entry in result.entries)
            {
                LeaderboardPlayer leaderboardPlayer = new LeaderboardPlayer();

                string name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = Anonymous;

                Action?.Invoke("YandexloadLeader: foreach - player name: " + entry.player.publicName);

                leaderboardPlayer.SetValue(entry.rank, name, entry.score);
                _players.Add(leaderboardPlayer);
                _currentAmount++;

                if (IsLeaderboardLoaded)
                    break;
            }
        });

        Action?.Invoke("YandexloadLeader: foreach - close. PlayerCount: " + _players.Count);
    }
}
