using UnityEngine;

public class Firework : MonoBehaviour
{
    [SerializeField] private LastDomino _lastDomino;

    private ParticleSystem[] _particles;

    private void Awake()
    {
        _particles = GetComponentsInChildren<ParticleSystem>();

        foreach (var particle in _particles)
            particle.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _lastDomino.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _lastDomino.Finished += OnFinished;
    }

    private void OnFinished()
    {
        foreach (var particle in _particles)
            particle.gameObject.SetActive(true);
    }
}
