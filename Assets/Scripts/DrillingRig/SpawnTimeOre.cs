using TMPro;
using UnityEngine;

public class SpawnTimeOre : MonoBehaviour
{
    [SerializeField] private OreMining _oreMining;
    [SerializeField] private UpgradingDrillingRig _upgradingDrillingRig;

    private TMP_Text _currentTime;

    private void Awake()
    {
        _currentTime = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _upgradingDrillingRig.Upgraded += OnUpgraded;
    }

    private void OnDisable()
    {
        _upgradingDrillingRig.Upgraded -= OnUpgraded;
    }

    private void OnUpgraded(int arg0)
    {
        _currentTime.text = _oreMining.CurrentSpawnTimeOre.ToString("#.#");
    }
}
