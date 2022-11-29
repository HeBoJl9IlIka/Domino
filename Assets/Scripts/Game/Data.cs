using UnityEngine;

public class Data : MonoBehaviour
{
    private const string Money = "money";
    private const string Level = "level";
    private const string Audio = "audio";
    private const string FirstStart = "firstStart";

    [SerializeField] private Level _level;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private Audio _audio;
    [SerializeField] private PlayerInterface _playerInterface;
    [SerializeField] private CheckingFirstStart _checkingFirstStart;

    private LoadingScene _loadingScene;

    public int LastOpeningLevel { get; private set; }
    public int AmountMoney => PlayerPrefs.GetInt(Money);
    public int ValueAudio => PlayerPrefs.GetInt(Audio);
    public bool IsFirstStart => PlayerPrefs.GetInt(FirstStart) == 0 ? true : false;

    private void Awake()
    {
        LastOpeningLevel = PlayerPrefs.GetInt(Level);
    }

    private void Start()
    {
        _loadingScene = GetComponent<LoadingScene>();
    }

    private void OnEnable()
    {
        _playerWallet.Changed += OnChanged;
        _level.Completed += OnCompleted;
        _audio.Changed += OnAudioChanged;
        _checkingFirstStart.Started += OnStarted;
    }

    private void OnDisable()
    {
        _playerWallet.Changed -= OnChanged;
        _level.Completed -= OnCompleted;
        _audio.Changed -= OnAudioChanged;
        _checkingFirstStart.Started -= OnStarted;
    }

    public void RemoveAllSave()
    {
        PlayerPrefs.DeleteAll();
    }

    private void OnChanged(int money)
    {
        PlayerPrefs.SetInt(Money, money);
    }
    
    private void OnCompleted(int arg0)
    {
        LastOpeningLevel++;

        if (LastOpeningLevel > _loadingScene.SceneCount - 1)
            LastOpeningLevel = 0;

        PlayerPrefs.SetInt(Level, LastOpeningLevel);
    }

    private void OnAudioChanged()
    {
        PlayerPrefs.SetInt(Audio, _playerInterface.IsAudioEnabled ? 1 : 0);
    }
    
    private void OnStarted()
    {
        PlayerPrefs.SetInt(FirstStart, 1);
    }
}
