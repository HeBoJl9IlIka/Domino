using UnityEngine;

public class EffectsInactiveDomino  : MonoBehaviour
{
    private Dust _dust;

    private void Start()
    {
        _dust = GetComponentInChildren<Dust>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_dust != null)
            if(_dust.TryGetComponent(out ParticleSystem particleSystem))
                particleSystem.Play();
    }
}
