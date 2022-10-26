using UnityEngine;
using UnityEngine.Events;

public class UpgradingDrillingRig : MonoBehaviour
{
    private const int _price = 300;

    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private ParticleSystem _confetti;
    [SerializeField] private GameObject _message;

    public event UnityAction Upgraded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (_playerWallet.TryBuy(_price))
            {
                Upgraded?.Invoke();
                _confetti.Play();
                gameObject.SetActive(false);
                _message.SetActive(false);
            }
        }
    }
}
