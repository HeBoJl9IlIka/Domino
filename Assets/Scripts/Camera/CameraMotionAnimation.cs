using UnityEngine;
using DG.Tweening;

public class CameraMotionAnimation : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _duration;

    private void OnEnable()
    {
        transform.DOMove(_targetPosition.position, _duration);
    }
}
