using UnityEngine;

public class SelectingMusic : MonoBehaviour
{
    private AudioSource[] _audioSources;

    public AudioSource CurrentMusic { get; private set; }

    private void Awake()
    {
        _audioSources = GetComponentsInChildren<AudioSource>();

        foreach (var audioSource in _audioSources)
            audioSource.gameObject.SetActive(false);

        CurrentMusic = _audioSources[Random.Range(0, _audioSources.Length)];
    }
}
