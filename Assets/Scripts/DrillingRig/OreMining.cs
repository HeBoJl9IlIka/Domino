using System;
using System.Linq;
using UnityEngine;

public class OreMining : MonoBehaviour
{
    private const float _upgradingSpawn = 0.2f;

    [SerializeField] private UpgradingDrillingRig _upgradingDrillingRig;
    [SerializeField] private OreAnimator[] _ores;
    [SerializeField] private float _delaySpawnOre;

    private float _time;

    private void Update()
    {
        if (_time < _delaySpawnOre)
        {
            _time += Time.deltaTime;
        }
        else
        {
            _time = 0;
            OreAnimator ore = _ores.FirstOrDefault(ore => ore.gameObject.activeSelf == false);

            if (ore != null)
                ore.gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {
        _upgradingDrillingRig.Upgraded += OnUpgraded;
    }

    private void OnDisable()
    {
        _upgradingDrillingRig.Upgraded -= OnUpgraded;
    }

    private void OnUpgraded()
    {
        _delaySpawnOre -= _upgradingSpawn;
    }
}
