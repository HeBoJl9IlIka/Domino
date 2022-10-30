using DG.Tweening;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private GameObject _containerPoint;

    private Transform[] _path;

    private void Start()
    {
        _path = _containerPoint.GetComponentsInChildren<Transform>();
    }

    private void OnEnable()
    {
        int numberTargetPoint = 0;
        transform.DOMove(_path[numberTargetPoint++].position, _duration);

        if (numberTargetPoint == _path.Length)
            numberTargetPoint = 0;

        enabled = true;
    }
}
