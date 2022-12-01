using TMPro;
using UnityEngine;

public class LanguageDetection : MonoBehaviour
{
    private const string EnglishCode = "en";
    private const string RussianCode = "ru";
    private const string TurkishCode = "tr";
    private const string EnglishLanguage = "English";
    private const string RussianLanguage = "Russian";
    private const string TurkishLanguage = "Turkish";

    [SerializeField] private YandexInitialization _yandexInitialization;

    private void OnEnable()
    {
        _yandexInitialization.Completed += OnCompleted;
    }

    private void OnDisable()
    {
        _yandexInitialization.Completed -= OnCompleted;
    }

    private void OnCompleted()
    {
        string language;

        switch (Agava.YandexGames.YandexGamesSdk.Environment.i18n.lang)
        {
            case EnglishCode:
                language = EnglishLanguage;
                break;
            case RussianCode:
                language = RussianLanguage;
                break;
            case TurkishCode:
                language = TurkishLanguage;
                break;
            default:
                language = EnglishLanguage;
                break;
        }

        Lean.Localization.LeanLocalization.SetCurrentLanguageAll(language);
    }
}
