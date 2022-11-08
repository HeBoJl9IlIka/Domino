using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ThiefAnimator : MonoBehaviour
{
    private const string Kick = "Kick";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayKick()
    {
        _animator.SetTrigger(Kick);
    }
}
