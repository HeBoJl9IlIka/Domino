using Agava.WebUtility;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SelectingMusic))]
public class Audio : MonoBehaviour
{
    private const float MaxValue = 1f;
    private const float MinValue = 0f;

    [SerializeField] private YandexAds _yandexAds;
    [SerializeField] private PlayerInterface _playerInterface;
    [SerializeField] private Data _data;

    private SelectingMusic _selectingMusic;

    public event UnityAction Changed;

    private void Start()
    {
        _selectingMusic = GetComponent<SelectingMusic>();
        EnableAudio();
    }

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
        _yandexAds.Shows += DisableAudio;
        _yandexAds.Showed += EnableAudio;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        _yandexAds.Shows -= DisableAudio;
        _yandexAds.Showed -= EnableAudio;
    }

    public void DisableAudio()
    {
        AudioListener.pause = true;
        AudioListener.volume = MinValue;
        Changed?.Invoke();
    }
    
    public void EnableAudio()
    {
        if ((_playerInterface.IsAudioEnabled) || (_data.ValueAudio == 1))
        {
            if (_selectingMusic.CurrentMusic.gameObject.activeSelf == false)
                _selectingMusic.CurrentMusic.gameObject.SetActive(true);

            AudioListener.pause = false;
            AudioListener.volume = MaxValue;
            Changed?.Invoke();
        }
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        AudioListener.pause = inBackground && _playerInterface.IsAudioEnabled == true;
        AudioListener.volume = inBackground ? 0f : 1f;
    }
}
