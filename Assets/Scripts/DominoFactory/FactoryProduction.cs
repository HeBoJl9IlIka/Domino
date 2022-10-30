using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class FactoryProduction : MonoBehaviour
{
    private const int _needAmount = 2;

    [SerializeField] private FactoryWarehouse _factoryWarehouse;
    [SerializeField] private DominoSpawning[] _dominos;
    [SerializeField] private float _delaySpawnDomino;

    private float _time;

    public event UnityAction<int> Produced;

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
                Produced?.Invoke(_needAmount);
            }
        }
    }
}
