using UnityEngine;

public class EnablingMusic : MonoBehaviour
{
    private AudioSource[] _audioSources;

    public AudioSource CurrentMusic { get; private set; }

    private void Awake()
    {
        _audioSources = GetComponentsInChildren<AudioSource>();
    }

    private void Start()
    {
        foreach (var audioSource in _audioSources)
            audioSource.gameObject.SetActive(false);

        CurrentMusic = _audioSources[Random.Range(0, _audioSources.Length)];
    }
}
