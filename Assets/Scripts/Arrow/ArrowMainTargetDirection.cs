using UnityEngine;

public class ArrowMainTargetDirection : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private DominoPlace _dominoPlace;
    [SerializeField] private DominoFactoryProduction _dominoFactoryProduction;
    [SerializeField] private Transform _pointTakingDomino;
    [SerializeField] private Transform _pointTakingOre;
    [SerializeField] private Transform _pointDrop;
    [SerializeField] private Transform _pointOreUnloading;
    [SerializeField] private Transform _target;

    private bool _isDominoActive;

    private void OnEnable()
    {
        _dominoFactoryProduction.Produced += OnProduced;
    }

    private void OnDisable()
    {
        _dominoFactoryProduction.Produced -= OnProduced;
    }

    private void Update()
    {
        if (_player.IsFull)
        {
            if (_player.IsDominoActive)
                _target = _dominoPlace.Target;
            else if (_player.IsOreActive)
                _target = _pointOreUnloading;
        }
        else
        {
            if (_isDominoActive)
                _target = _pointTakingDomino;
            else
                _target = _pointTakingOre;
        }

        Vector3 targetPostition = new Vector3(_target.position.x, this.transform.position.y, _target.position.z);
        this.transform.LookAt(targetPostition);
    }

    private void OnProduced(int arg0)
    {
        _isDominoActive = true;
    }
}
