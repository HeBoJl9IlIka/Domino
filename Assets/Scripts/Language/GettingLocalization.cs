using Lean.Localization;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class GettingLocalization : MonoBehaviour
{
    [SerializeField] private LanguageDetection _languageDetection;
    [SerializeField] private LeanPhrase _phrase;

    private TMP_Text _string;

    private void Awake()
    {
        _string = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (_languageDetection)
        {
            _string.text = Lean.Localization.LeanLocalization.GetTranslationText(_phrase.name);
            enabled = false;
        }
    }
}
