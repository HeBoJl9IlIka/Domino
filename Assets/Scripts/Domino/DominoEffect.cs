using UnityEngine;

[RequireComponent(typeof(DominoPlace))]
public class DominoEffect : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _dominos;
    [SerializeField] private Rigidbody _firstDomino;
    [SerializeField] private float _speed;

    private DominoPlace _dominoPlace;

    private void Awake()
    {
        _dominoPlace = GetComponent<DominoPlace>();    
    }

    private void OnEnable()
    {
        _dominoPlace.AllShowed += OnAllShowed;
    }

    private void OnDisable()
    {
        _dominoPlace.AllShowed -= OnAllShowed;
    }

    private void OnAllShowed()
    {
        Invoke(nameof(Launch), 1f);
    }

    private void Launch()
    {
        foreach (var domino in _dominos)
            domino.isKinematic = false;

        _firstDomino.AddRelativeForce(Vector3.left * _speed * Time.deltaTime, ForceMode.VelocityChange);
    }
}
