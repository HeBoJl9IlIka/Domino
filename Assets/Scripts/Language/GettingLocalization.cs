using Lean.Localization;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class GettingLocalization : MonoBehaviour
{
    private const string Next = "Next";
    private const string LevelComplete = "Level complete";
    private const string GetRobotFree = "Get robot free";
    private const string Error = "Error";

    [SerializeField] private LanguageDetection _languageDetection;
    [SerializeField] private Text _phrase;

    private TMP_Text _string;

    private enum Text
    {
        Next,
        LevelComplete,
        GetRobotFree
    }

    private void Start()
    {
        _string = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (_languageDetection)
        {
            string phrase = "";

            switch (_phrase)
            {
                case Text.Next:
                    phrase = Next;
                    break;
                case Text.LevelComplete:
                    phrase = LevelComplete;
                    break;
                case Text.GetRobotFree:
                    phrase = GetRobotFree;
                    break;
                default:
                    phrase = Error;
                    break;
            }

            _string.text = Lean.Localization.LeanLocalization.GetTranslationText(phrase);
            enabled = false;
        }
    }
}
