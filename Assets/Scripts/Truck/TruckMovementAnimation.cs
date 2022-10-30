using DG.Tweening;
using UnityEngine;

public class TruckMovementAnimation : MonoBehaviour
{
    [SerializeField] private float _duration;

    private Tween _currentTween;

    public bool IsPlay => _currentTween.IsActive();

    public void Play(Transform target)
    {
        _currentTween = transform.DOMove(target.position, _duration);
    }
}
