#pragma warning disable

using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class YandexInitialization : MonoBehaviour
{
    public event UnityAction<string> Action;

    private IEnumerator Start()
    {
        Action?.Invoke("YandexInit start");
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        Action?.Invoke("YandexInit: Unity webgl = true");
        yield return YandexGamesSdk.Initialize(() => PlayerAccount.RequestPersonalProfileDataPermission());
        Action?.Invoke("YandexInit: YandexInit = true");
    }
}
