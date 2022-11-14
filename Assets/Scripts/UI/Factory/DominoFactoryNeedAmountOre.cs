using TMPro;
using UnityEngine;

public class DominoFactoryNeedAmountOre : MonoBehaviour
{
    [SerializeField] private DominoFactoryUpgrade _factoryUpgrade;
    [SerializeField] private DominoFactoryWarehouse _factoryWarehause;
    [SerializeField] private DominoFactoryProduction _factoryProduction;

    private TMP_Text _amount;

    private string _text => _factoryWarehause.OreCount.ToString() + " / " + _factoryProduction.NeedAmount.ToString();

    private void Awake()
    {
        _amount = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _factoryWarehause.Loaded += OnLoaded;
        _factoryUpgrade.Upgraded += OnUpgraded;
        _factoryProduction.Produced += OnProduced;
    }

    private void OnDisable()
    {
        _factoryWarehause.Loaded -= OnLoaded;
        _factoryUpgrade.Upgraded -= OnUpgraded;
        _factoryProduction.Produced -= OnProduced;
    }

    private void OnLoaded(uint arg0)
    {
        _amount.text = _text;
    }

    private void OnUpgraded(int arg0)
    {
        _amount.text = _text;
    }
    
    private void OnProduced(int arg0)
    {
        _amount.text = _text;
    }
}
