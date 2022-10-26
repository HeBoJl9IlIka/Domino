using UnityEngine;

public class EffectsActiveDomino : MonoBehaviour
{
    private Dust _dust;

    private void Start()
    {
        _dust = GetComponentInChildren<Dust>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out DominoPushing dominoPushing))
        {
            dominoPushing.Push();

            if (_dust != null)
                if (_dust.TryGetComponent(out ParticleSystem particleSystem))
                    particleSystem.Play();
        }
    }
}
