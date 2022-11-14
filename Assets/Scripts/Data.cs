using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LoadingScene))]
public class Data : MonoBehaviour
{
    private const string Money = "money";
    private const string Level = "level";

    [SerializeField] private Level _level;
    [SerializeField] private PlayerWallet _playerWallet;

    private LoadingScene _loadingScene;

    public int LastOpeningLevel { get; private set; }

    public event UnityAction<int> MoneyLoaded;

    private void Awake()
    {
        LastOpeningLevel = PlayerPrefs.GetInt(Level);
        MoneyLoaded?.Invoke(PlayerPrefs.GetInt(Money));
    }

    private void Start()
    {
        _loadingScene = GetComponent<LoadingScene>();

        if(LastOpeningLevel != _loadingScene.CurrentScene)
            _loadingScene.Open(LastOpeningLevel);
    }

    private void OnEnable()
    {
        _playerWallet.Changed += OnChanged;
        _level.Completed += OnCompleted;
    }

    private void OnDisable()
    {
        _playerWallet.Changed -= OnChanged;
        _level.Completed -= OnCompleted;
    }

    public void RemoveAllSave()
    {
        PlayerPrefs.DeleteAll();
    }

    private void OnChanged(int value)
    {
        PlayerPrefs.SetInt(Money, value);
    }
    
    private void OnCompleted(int arg0)
    {
        LastOpeningLevel++;

        if (LastOpeningLevel > _loadingScene.SceneCount)
            LastOpeningLevel = 0;

        PlayerPrefs.SetInt(Level, LastOpeningLevel);
    }
}
