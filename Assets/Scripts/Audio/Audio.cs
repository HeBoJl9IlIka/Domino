using Agava.WebUtility;
using UnityEngine;

[RequireComponent(typeof(EnablingMusic))]
public class Audio : MonoBehaviour
{
    private const float MaxValue = 1f;
    private const float MinValue = 0f;

    [SerializeField] private YandexAds _yandexAds;

    private EnablingMusic _enablingMusic;

    private void Start()
    {
        _enablingMusic = GetComponent<EnablingMusic>();
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
    }
    
    public void EnableAudio()
    {
        if (_enablingMusic.CurrentMusic.gameObject.activeSelf == false)
            _enablingMusic.CurrentMusic.gameObject.SetActive(true);

        AudioListener.pause = false;
        AudioListener.volume = MaxValue;
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        AudioListener.pause = inBackground;
        AudioListener.volume = inBackground ? 0f : 1f;
    }
}
