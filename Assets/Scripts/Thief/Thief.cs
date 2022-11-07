using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ThiefPickDomino))]
[RequireComponent(typeof(ThiefMovement))]
[RequireComponent(typeof(ThiefAnimator))]
public class Thief : MonoBehaviour
{
    [SerializeField] private DominoThief _inactiveDomino;
    [SerializeField] private ParticleSystem _smokeKick;

    private ThiefSpawn _thiefSpawn;
    private ThiefMovement _thiefMovement;
    private ThiefAnimator _thiefAnimator;
    private Domino _domino;
    private bool _isKicked;

    public bool IsTookDomino { get; private set; }
    public bool DominoIsReady => _inactiveDomino.gameObject.activeSelf == false;

    public event UnityAction Stolen;

    private void Start()
    {
        _thiefSpawn = GetComponentInParent<ThiefSpawn>();
        _thiefMovement = GetComponent<ThiefMovement>();
        _thiefAnimator = GetComponent<ThiefAnimator>();
        _domino = GetComponentInChildren<Domino>();

        gameObject.SetActive(false);
    }

    private void Update()
    {
        if ((IsTookDomino) || (_isKicked))
            if (_thiefMovement.IsEscaped)
            {
                gameObject.SetActive(false);
                _isKicked = false;
                IsTookDomino = false;
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isKicked == false)
        {
            if (other.TryGetComponent(out Player player))
            {
                if (IsTookDomino)
                {
                    _inactiveDomino.gameObject.SetActive(true);
                    IsTookDomino = false;
                }

                _isKicked = true;
                _domino.gameObject.SetActive(false);
                _smokeKick.Play();
                Escape();
            }
        }

        if (IsTookDomino == false)
        {
            if (other.TryGetComponent(out PointDomino pointDomino))
            {
                pointDomino.HideDomino();
                _domino.gameObject.SetActive(true);
                IsTookDomino = true;
                Stolen?.Invoke();
                Escape();
            }
        }
    }

    public void Steal(Domino domino)
    {
        _domino.gameObject.SetActive(false);
        transform.position = _thiefSpawn.Target.transform.position;
        _thiefMovement.Move(domino.transform);
    }

    private void Escape()
    {
        _thiefMovement.Move(_thiefSpawn.Target.transform);
    }
}
