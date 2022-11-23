#pragma warning disable

using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using UnityEngine;
using UnityEngine.UI;

public class YnadexSDK : MonoBehaviour
{
    private const string LeaderboardName = "dominoLeaderboard";
    private const int MaxPlayers = 6;

    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private LastDomino _lastDomino;

    private List<LeaderboardPlayer> _players;

    public LeaderboardPlayer[] Players => _players.ToArray();
    public bool IsLeaderboardLoaded { get; private set; }

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();

        _players = new List<LeaderboardPlayer>();

        if (IsLeaderboardLoaded == false)
        {
            LoadLeaderboard();
            IsLeaderboardLoaded = true;
        }
    }

    private void OnEnable()
    {
        _lastDomino.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _lastDomino.Finished -= OnFinished;
    }

    public void OnShowVideoButtonClick()
    {
        VideoAd.Show();
    }

    private void LoadLeaderboard()
    {
        LeaderboardPlayer leaderboardPlayer = new LeaderboardPlayer();

        Leaderboard.GetEntries(LeaderboardName, (result) =>
        {
            for (int i = 0; i < MaxPlayers; i++)
            {
                if (result == null)
                    return;

                string name = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";

                leaderboardPlayer.SetValue(result.entries[i].rank, name, result.entries[i].score);

                _players.Add(leaderboardPlayer);
            }
        });
    }

    private void OnFinished()
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
