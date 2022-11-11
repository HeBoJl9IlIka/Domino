using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class AnimationMoneyMovement : MonoBehaviour
{
    private const float _maxDelay = 0.2f;

    [SerializeField] private RectTransform _defaultPosition;
    [SerializeField] private RectTransform _firstPosition;
    [SerializeField] private RectTransform _targetPosition;
    [SerializeField] private float _duration;

    private RectTransform _transform;
    private Sequence _sequence;
    private float _delay;

    private bool _isPlaying => _transform.position != _targetPosition.position;

    public event UnityAction Played;

    private void Update()
    {
        if (_sequence.IsActive())
            return;

        Played?.Invoke();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _delay = Random.Range(0, _maxDelay);
        _transform = GetComponent<RectTransform>();

        _sequence = DOTween.Sequence();

        _sequence.Append(_transform.DOMove(_firstPosition.position, _duration).SetDelay(_delay));
        _sequence.Append(_transform.DOMove(_targetPosition.position, _duration).SetDelay(_delay));
    }

    private void OnDisable()
    {
        _transform.position = _defaultPosition.position;
    }
}
