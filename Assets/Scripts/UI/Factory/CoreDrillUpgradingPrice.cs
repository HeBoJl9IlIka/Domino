using TMPro;
using UnityEngine;

public class CoreDrillUpgradingPrice : MonoBehaviour
{
    [SerializeField] private UpgradingDrillingRig _drilling;

    private TMP_Text _price;

    private void Awake()
    {
        _price = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _drilling.Upgraded += OnUpgraded;
        _drilling.FullUpgraded += OnFullUpgraded;
    }

    private void OnDisable()
    {
        _drilling.Upgraded -= OnUpgraded;
        _drilling.FullUpgraded -= OnFullUpgraded;
    }

    private void OnUpgraded(int price)
    {
        _price.text = price.ToString();
    }

    private void OnFullUpgraded()
    {
        gameObject.SetActive(false);
    }
}


