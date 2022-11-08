using TMPro;
using UnityEngine;

public class RobotFactoryUpgradingPrice : MonoBehaviour
{
    [SerializeField] private RobotFactoryUpgrade _factory;

    private TMP_Text _price;

    private void Awake()
    {
        _price = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _factory.Upgraded += OnUpgraded;
        _factory.FullUpgraded += OnFullUpgraded;
    }

    private void OnDisable()
    {
        _factory.Upgraded -= OnUpgraded;
        _factory.FullUpgraded -= OnFullUpgraded;
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
