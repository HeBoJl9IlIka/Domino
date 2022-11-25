using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;

public class YandexLeaderboardLoading : MonoBehaviour
{
    private static List<LeaderboardPlayer> _players;

    private const int MaxAmount = 6;
    private const string Anonymous = "Anonymous";
    private const string LeaderboardName = "dominoLeaderboard";

    private int _currentAmount;

    public LeaderboardPlayer[] Players => _players.ToArray();
    public bool IsLeaderboardLoaded => _currentAmount >= MaxAmount;

    private void OnEnable()
    {
        if(IsLeaderboardLoaded == false)
            _players = new List<LeaderboardPlayer>();

        Leaderboard.GetEntries(LeaderboardName, (result) =>
        {
            foreach (var entry in result.entries)
            {
                LeaderboardPlayer leaderboardPlayer = new LeaderboardPlayer();

                string name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = Anonymous;

                leaderboardPlayer.SetValue(entry.rank, name, entry.score);
                _players.Add(leaderboardPlayer);
                _currentAmount++;

                if (IsLeaderboardLoaded)
                    break;
            }
        });
    }
}
