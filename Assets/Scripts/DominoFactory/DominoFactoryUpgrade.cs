using UnityEngine;
using UnityEngine.Events;

public class DominoFactoryUpgrade : MonoBehaviour
{
    [SerializeField] private DominoFactoryProduction _factory;
    [SerializeField] private GameObject _icon;
    [SerializeField] private int _price;

    private ParticleSystem _confetti;
    private int _priceStep;

    public event UnityAction<int> Upgraded;
    public event UnityAction FullUpgraded;

    private void Awake()
    {
        _confetti = GetComponentInChildren<ParticleSystem>();
        _priceStep = _price;

        Upgraded?.Invoke(_price);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_factory.IsMaxUpgrade == false)
        {
            if (other.TryGetComponent(out PlayerWallet player))
            {
                if (player.TryBuy(_price))
                {
                    _price += _priceStep;
                    _confetti.Play();
                    _factory.Upgrade();
                    Upgraded?.Invoke(_price);

                    if (_factory.IsMaxUpgrade)
                    {
                        FullUpgraded?.Invoke();
                        _icon.SetActive(false);
                    }
                }
            }
        }
    }
}
