using UnityEngine;

public class ManualControl : MonoBehaviour
{
    [SerializeField] private YandexInitialization _yandexInitialization;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _touch;
    [SerializeField] private GameObject _keyboard;

    private void Update()
    {
        if(_playerMovement.IsPressed)
        {
            _keyboard.SetActive(false);
            _touch.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _yandexInitialization.Completed += OnCompleted;
    }

    private void OnDisable()
    {
        _yandexInitialization.Completed -= OnCompleted;
    }

    private void OnCompleted()
    {
        if (Agava.YandexGames.Device.Type == Agava.YandexGames.DeviceType.Desktop)
            _keyboard.SetActive(true);
        else
            _touch.SetActive(true);
    }
}
