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

    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private LastDomino _lastDomino;
    [SerializeField] private Text _authorizationStatusText;
    [SerializeField] private Text _personalProfileDataPermissionStatusText;
    [SerializeField] private Text _leaderboard;

    private LeaderboardPlayer _player;
    private List<LeaderboardPlayer> _players;

    public LeaderboardPlayer CurrentPlayer => _player;
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
            GetLeaderboard();
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

    private void GetCurrentPlayerRank()
    {
        LeaderboardPlayer leaderboardPlayer = new LeaderboardPlayer();

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result == null)
            {
                leaderboardPlayer.SetRank(0);
                leaderboardPlayer.SetName(result.player.publicName);
                leaderboardPlayer.SetScore(_playerWallet.Money);
            }
            else
            {
                leaderboardPlayer.SetRank(result.rank);
                leaderboardPlayer.SetName(result.player.publicName);
                leaderboardPlayer.SetScore(result.score);
            }

            _player = leaderboardPlayer;
        });
    }

    private void GetLeaderboard()
    {
        LeaderboardPlayer leaderboardPlayer = new LeaderboardPlayer();

        Leaderboard.GetEntries(LeaderboardName, (result) =>
        {
            for (int i = 0; i < 6; i++)
            {
                string name = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";

                leaderboardPlayer.SetRank(result.entries[i].rank);
                leaderboardPlayer.SetName(name);
                leaderboardPlayer.SetScore(result.entries[i].score);

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
