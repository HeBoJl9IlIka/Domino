#pragma warning disable

using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class YandexInitialization : MonoBehaviour
{
    private const string LeaderboardName = "dominoLeaderboard";

    public event UnityAction PlayerAuthorizated;
    public event UnityAction Completed;

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize(() => PlayerAccount.RequestPersonalProfileDataPermission());

        Completed?.Invoke();

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result != null)
                PlayerAuthorizated?.Invoke();
        });
    }
}
