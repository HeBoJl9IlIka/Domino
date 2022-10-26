using UnityEngine;
using DG.Tweening;

public class AnimationMovingDomino : MonoBehaviour
{
    [SerializeField] private Domino _domino;
    [SerializeField] private Transform _firstPosition;
    [SerializeField] private Transform _secondPosition;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _duration;

    private void OnEnable()
    {
        _domino.transform.position = _firstPosition.position;
        _domino.transform.rotation = _firstPosition.rotation;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(_domino.transform.DOMove(_secondPosition.position, _duration));
        sequence.Insert(0, _domino.transform.DORotate(_targetPosition.eulerAngles, _duration));

        sequence.Append(_domino.transform.DOMove(_targetPosition.position, _duration));
    }
}
