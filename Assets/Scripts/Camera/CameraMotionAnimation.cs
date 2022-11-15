using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class CameraMotionAnimation : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _duration;

    private Tween _tween;

    private bool _isPlaying => _tween.IsActive();

    public event UnityAction Played;

    private void Update()
    {
        if (_isPlaying == false)
            Played?.Invoke();
    }

    private void OnEnable()
    {
        _tween = transform.DOMove(_targetPosition.position, _duration);
    }
}
