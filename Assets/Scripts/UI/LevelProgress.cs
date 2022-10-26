using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    private const float _delay = 3f;

    [SerializeField] private LastDomino _lastDomino;
    [SerializeField] private GameObject _finishPanel;

    private void OnEnable()
    {
        _lastDomino.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _lastDomino.Finished -= OnFinished;
    }

    private void OnFinished()
    {
        Invoke(nameof(ShowFinishPanel), _delay);
    }

    private void ShowFinishPanel()
    {
        _finishPanel.SetActive(true);
    }
}
