using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Data))]
public class LoadingScene : MonoBehaviour
{
    private Data _dataSaving;

    public int SceneCount => SceneManager.sceneCountInBuildSettings;
    public int CurrentScene => SceneManager.GetActiveScene().buildIndex;

    private void Start()
    {
        _dataSaving = GetComponent<Data>();
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
