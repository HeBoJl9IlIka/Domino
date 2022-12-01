using TMPro;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField] private YandexInitialization _yandexInitialization;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private TMP_Text _money;
    [SerializeField] private GameObject _iconLeaderboard;
    [SerializeField] private GameObject _iconAudioEnabled;
    [SerializeField] private GameObject _iconAudioDisabled;
    [SerializeField] private Data _data;

    public bool IsAudioEnabled => _iconAudioEnabled.gameObject.activeSelf;

    private void Awake()
    {
        _iconAudioEnabled.gameObject.SetActive(_data.IsAudioEnable);
        _iconAudioDisabled.gameObject.SetActive(_data.IsAudioEnable ? false : true);
    }

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
