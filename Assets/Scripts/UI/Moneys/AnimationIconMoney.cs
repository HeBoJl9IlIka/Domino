using UnityEngine;
using DG.Tweening;

public class AnimationIconMoney : MonoBehaviour
{
    private const float _duration = 0.1f;

    [SerializeField] private AnimationMoneyMovement[] _wadsMoney;

    private RectTransform _transform;
    private Vector3 _defaultScale;

    private void Start()
    {
        _transform = GetComponent<RectTransform>();
        _defaultScale = transform.localScale;
    }

    private void OnEnable()
    {
        foreach (var wadMoney in _wadsMoney)
        {
            wadMoney.Played += OnPlayed;
        }
    }

    private void OnDisable()
    {
        foreach (var wadMoney in _wadsMoney)
        {
            wadMoney.Played -= OnPlayed;
        }
    }

    private void OnPlayed()
    {
        _transform.localScale = _defaultScale;
        Vector3 targetValue = new Vector3(1.1f, 1.1f, 1.1f);

        Sequence sequence = DOTween.Sequence();

        sequence.Append(_transform.DOScale(targetValue, _duration));
        sequence.Append(_transform.DOScale(_defaultScale, _duration));
    }
}
