using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(RobotSpawner))]
public class RobotFactoryUpgrade : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private GameObject _icon;
    
    private ParticleSystem _confetti;
    private RobotSpawner _spawner;
    private int _priceStep;

    public event UnityAction<int> Upgraded;
    public event UnityAction FullUpgraded;

    private void Awake()
    {
        _spawner = GetComponent<RobotSpawner>();
        _confetti = GetComponentInChildren<ParticleSystem>();
        _priceStep = _price;

        Upgraded?.Invoke(_price);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_spawner.IsFull)
        {
            if (other.TryGetComponent(out PlayerWallet player))
            {
                if (player.TryBuy(_price))
                {
                    _price += _priceStep;
                    _confetti.Play();
                    _spawner.enabled = true;
                    Upgraded?.Invoke(_price);

                    if (_spawner.IsFull == false)
                    {
                        FullUpgraded?.Invoke();
                        _icon.SetActive(false);
                    }
                }
            }
        }
    }
}
