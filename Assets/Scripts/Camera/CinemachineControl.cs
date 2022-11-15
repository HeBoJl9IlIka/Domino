using UnityEngine;

public class CinemachineControl: MonoBehaviour
{
    [SerializeField] private DominoPlace _dominoPlace;
    [SerializeField] private LastDomino _lastDomino;
    [SerializeField] private GameObject _virtualCamera1;
    [SerializeField] private GameObject _virtualCamera2;
    [SerializeField] private GameObject _virtualCamera3;
    [SerializeField] private GameObject _virtualCamera4;

    private CameraMotionAnimation _cameraMotionAnimation;

    private void Awake()
    {
        if(_virtualCamera4.TryGetComponent(out CameraMotionAnimation cameraMotionAnimation))
            _cameraMotionAnimation = cameraMotionAnimation;
    }

    private void Start()
    {
        if (_cameraMotionAnimation != null)
            _virtualCamera4.SetActive(true);
        else
            _virtualCamera1.SetActive(true);
    }

    private void OnEnable()
    {
        _dominoPlace.AllShowed += OnAllShowed;
        _lastDomino.Finished += OnFinished;
        _cameraMotionAnimation.Played += OnPlayed;
    }

    private void OnDisable()
    {
        _dominoPlace.AllShowed -= OnAllShowed;
        _lastDomino.Finished -= OnFinished;
        _cameraMotionAnimation.Played += OnPlayed;
    }

    private void OnAllShowed()
    {
        _virtualCamera1.SetActive(false);
        _virtualCamera2.SetActive(true);
    }

    private void OnFinished()
    {
        _virtualCamera2.SetActive(false);
        _virtualCamera3.SetActive(true);
    }
    
    private void OnPlayed()
    {
        _virtualCamera4.SetActive(false);
        _virtualCamera1.SetActive(true);
    }
}
