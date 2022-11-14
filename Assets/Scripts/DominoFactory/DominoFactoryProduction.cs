using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DominoFactoryProduction : MonoBehaviour
{
    [SerializeField] private DominoFactoryWarehouse _factoryWarehouse;
    [SerializeField] private DominoSpawning[] _dominos;
    [SerializeField] private float _delaySpawnDomino;
    [SerializeField] private int _needAmount;

    private float _time;

    public int NeedAmount => _needAmount;
    public bool IsMaxUpgrade => _needAmount == 1;

    public event UnityAction<int> Produced;

    public void Upgrade()
    {
        --_needAmount;
    }

    private void Update()
    {
        if (_factoryWarehouse.OreCount < _needAmount)
            return;

        if (_time < _delaySpawnDomino)
        {
            _time += Time.deltaTime;
        }
        else
        {
            _time = 0;
            DominoSpawning domino = _dominos.FirstOrDefault(domino => domino.gameObject.activeSelf == false);

            if (domino != null)
            {
                domino.gameObject.SetActive(true);
                _factoryWarehouse.RemoveOre(_needAmount);
                Produced?.Invoke(_needAmount);
            }
        }
    }
}
