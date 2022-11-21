using System.Linq;
using UnityEngine;

public class OreMining : MonoBehaviour
{
    private const float _upgradingSpawn = 0.2f;
    private const float _minTimeSpawn = 1.2f;

    [SerializeField] private OreAnimator[] _ores;
    [SerializeField] private float _delaySpawnOre;

    private float _time;

    public float CurrentSpawnTimeOre => _delaySpawnOre;
    public bool IsMaxUpgrade => _delaySpawnOre <= _minTimeSpawn;

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

    public void Upgrade()
    {
        if (IsMaxUpgrade)
            return;

        _delaySpawnOre -= _upgradingSpawn;
    }
}
