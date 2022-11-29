using UnityEngine;

public class Data : MonoBehaviour
{
    private const string Money = "money";
    private const string Level = "level";
    private const string Audio = "audio";

    [SerializeField] private Level _level;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private Audio _audio;
    [SerializeField] private PlayerInterface _playerInterface;

    private LoadingScene _loadingScene;

    public int LastOpeningLevel { get; private set; }
    public int AmountMoney => PlayerPrefs.GetInt(Money);
    public int ValueAudio => PlayerPrefs.GetInt(Audio);

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
    }

    private void OnDisable()
    {
        _playerWallet.Changed -= OnChanged;
        _level.Completed -= OnCompleted;
        _audio.Changed -= OnAudioChanged;
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
}
