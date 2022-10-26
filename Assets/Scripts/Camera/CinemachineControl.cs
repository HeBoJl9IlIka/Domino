using UnityEngine;

public class CinemachineControl: MonoBehaviour
{
    [SerializeField] private DominoPlace _dominoPlace;
    [SerializeField] private LastDomino _lastDomino;
    [SerializeField] private GameObject _virtualCamera1;
    [SerializeField] private GameObject _virtualCamera2;
    [SerializeField] private GameObject _virtualCamera3;
    
    private void OnEnable()
    {
        _dominoPlace.AllShowed += OnAllShowed;
        _lastDomino.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _dominoPlace.AllShowed -= OnAllShowed;
        _lastDomino.Finished -= OnFinished;
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
}
