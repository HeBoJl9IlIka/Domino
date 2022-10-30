using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class PriceUpgradingRobotFactory : MonoBehaviour
{
    [SerializeField] private RobotFactoryUpgrade _robotFactory;

    private TMP_Text _price;

    private void Awake()
    {
        _price = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _robotFactory.Upgraded += OnUpgraded;
        _robotFactory.FullUpgraded += OnFullUpgraded;
    }

    private void OnDisable()
    {
        _robotFactory.Upgraded -= OnUpgraded;
        _robotFactory.FullUpgraded -= OnFullUpgraded;
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
