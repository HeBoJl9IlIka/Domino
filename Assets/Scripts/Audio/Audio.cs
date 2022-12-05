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

        if (_playerInterface.IsAudioEnabled)
            EnableAudio();
    }

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
        _yandexAds.Shows += DisableAudio;
        _yandexAds.Showed += OnShowed;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        _yandexAds.Shows -= DisableAudio;
        _yandexAds.Showed -= OnShowed;
    }

    public void DisableAudio()
    {
        AudioListener.pause = true;
        AudioListener.volume = MinValue;
        Changed?.Invoke();
    }
    
    public void EnableAudio()
    {
        if (_selectingMusic.CurrentMusic.gameObject.activeSelf == false)
            _selectingMusic.CurrentMusic.gameObject.SetActive(true);

        AudioListener.pause = false;
        AudioListener.volume = MaxValue;
        Changed?.Invoke();
    }

    private void OnShowed()
    {
        if (_playerInterface.IsAudioEnabled)
            EnableAudio();
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        if (inBackground)
        {
            AudioListener.pause = true;
            AudioListener.volume = MinValue;
        }
        else
        {
            if (_playerInterface.IsAudioEnabled)
            {
                AudioListener.pause = false;
                AudioListener.volume = MaxValue;
            }
        }
    }
}
