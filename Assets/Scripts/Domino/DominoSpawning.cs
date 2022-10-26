using UnityEngine;

public class DominoSpawning : MonoBehaviour
{
    [SerializeField] private Transform _defaultPosition;
    [SerializeField] private Transform _targetPosition;

    private Animator _animator;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position != _targetPosition.transform.position)
            return;

        _animator.enabled = false;
        _rigidbody.isKinematic = false;
    }

    public void Reset()
    {
        transform.position = _defaultPosition.position;
        _animator.enabled = true;
        _rigidbody.isKinematic = true;
    }
}
