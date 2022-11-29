using UnityEngine;
using UnityEngine.UI;

public class Manual : MonoBehaviour
{
    [SerializeField] private PlayerTakingOre _playerTakingOre;
    [SerializeField] private PlayerDroppingOre _playerDroppingOre;
    [SerializeField] private PlayerTakingDomino _playerTakingDomino;
    [SerializeField] private PlayerDropDomino _playerDropDomino;
    [SerializeField] private Transform _arrow;
    [SerializeField] private Transform[] _pointsOfAction;

    private Slide[] _slides;
    private Image _blackout;
    private int _slideNumber;

    private void Awake()
    {
        _slides = GetComponentsInChildren<Slide>();
        _blackout = GetComponentInChildren<Image>();

        foreach (Slide slide in _slides)
            slide.gameObject.SetActive(false);

        _blackout.gameObject.SetActive(false);
    }

    private void Start()
    {
        OnAction();
    }

    private void OnEnable()
    {
        _playerTakingOre.Taked += OnAction;
        _playerDroppingOre.Droped += OnAction;
        _playerTakingDomino.Taked += OnAction;
        _playerDropDomino.Droped += OnDroped;
    }

    private void OnDisable()
    {
        _playerTakingOre.Taked -= OnAction;
        _playerDroppingOre.Droped -= OnAction;
        _playerTakingDomino.Taked -= OnAction;
        _playerDropDomino.Droped -= OnDroped;
    }

    private void OnAction()
    {
        if (_slideNumber >= _slides.Length)
            OnDroped();

        _blackout.gameObject.SetActive(false);
        _blackout.gameObject.SetActive(true);
        _arrow.position = new Vector3(_pointsOfAction[_slideNumber].position.x, _arrow.position.y, _pointsOfAction[_slideNumber].position.z);
        _slides[_slideNumber++].gameObject.SetActive(true);
    }

    private void OnDroped()
    {
        _arrow.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
