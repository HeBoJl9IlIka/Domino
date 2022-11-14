using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(DataSaving))]
public class LoadingScene : MonoBehaviour
{
    private DataSaving _dataSaving;

    public int SceneCount => SceneManager.sceneCount;
    public int CurrentScene => SceneManager.GetActiveScene().buildIndex;

    private void Start()
    {
        _dataSaving = GetComponent<DataSaving>();
    }

    public void Open(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }

    public void OpenNext()
    {
        SceneManager.LoadScene(_dataSaving.LastOpeningLevel);
    }
}
