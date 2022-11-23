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

    //[SerializeField]
    //private InputField _playerDataTextField;

    private List<string> _players;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        // Always wait for it if invoking something immediately in the first scene.
        yield return YandexGamesSdk.Initialize();

        GetLeaderboard();

        while (true)
        {
            _authorizationStatusText.color = PlayerAccount.IsAuthorized ? Color.green : Color.red;

            if (PlayerAccount.IsAuthorized)
                _personalProfileDataPermissionStatusText.color = PlayerAccount.HasPersonalProfileDataPermission ? Color.green : Color.red;
            else
                _personalProfileDataPermissionStatusText.color = Color.red;

            yield return new WaitForSecondsRealtime(0.25f);
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

    //public void OnShowInterstitialButtonClick()
    //{
    //    InterstitialAd.Show();
    //}

    public void OnShowVideoButtonClick()
    {
        VideoAd.Show();
    }

    //public void OnAuthorizeButtonClick()
    //{
    //    PlayerAccount.Authorize();
    //}

    //public void OnRequestPersonalProfileDataPermissionButtonClick()
    //{
    //    PlayerAccount.RequestPersonalProfileDataPermission();
    //}

    //public void OnGetProfileDataButtonClick()
    //{
    //    PlayerAccount.GetProfileData((result) =>
    //    {
    //        string name = result.publicName;
    //        if (string.IsNullOrEmpty(name))
    //            name = "Anonymous";
    //        Debug.Log($"My id = {result.uniqueID}, name = {name}");
    //    });
    //}

    //public void OnSetLeaderboardScoreButtonClick()
    //{
    //    Leaderboard.SetScore("dominoLeaderboard", Random.Range(1, 100));
    //}

    private void GetLeaderboard()
    {
        Leaderboard.GetEntries(LeaderboardName, (result) =>
        {
            //Debug.Log($"My rank = {result.userRank}");
            for (int i = 0; i < 6; i++)
            {
                string name = result.entries[i].player.publicName;
                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";
                _leaderboard.text += result.entries[i].rank.ToString() + " " + name + " " + result.entries[i].score + "\n";
                //_players.Add(result.entries[i].rank.ToString() + " " + name + " " + result.entries[i].score);
            }
        });
    }

    //public void OnGetLeaderboardPlayerEntryButtonClick()
    //{
        
    //}

    //public void OnSetPlayerDataButtonClick()
    //{
    //    PlayerAccount.SetPlayerData(_playerDataTextField.text);
    //}

    //public void OnGetPlayerDataButtonClick()
    //{
    //    PlayerAccount.GetPlayerData((data) => _playerDataTextField.text = data);
    //}

    //public void OnGetDeviceTypeButtonClick()
    //{
    //    Debug.Log($"DeviceType = {Device.Type}");
    //}

    //public void OnGetEnvironmentButtonClick()
    //{
    //    Debug.Log($"Environment = {JsonUtility.ToJson(YandexGamesSdk.Environment)}");
    //}

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
