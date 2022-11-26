using TMPro;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField] private YandexInitialization _yandexInitialization;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private TMP_Text _money;
    [SerializeField] private GameObject _iconLeaderboard;

    private void OnEnable()
    {
        _yandexInitialization.PlayerAuthorizated += OnPlayerAuthorizated;
        _playerWallet.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _yandexInitialization.PlayerAuthorizated -= OnPlayerAuthorizated;
        _playerWallet.Changed -= OnChanged;
    }

    private void OnChanged(int money)
    {
        _money.text = money.ToString();
    }

    private void OnPlayerAuthorizated()
    {
        _iconLeaderboard.SetActive(true);
    }
}
