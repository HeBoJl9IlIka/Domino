using UnityEngine;
using UnityEngine.Events;

public class PlayerDroppingOre : MonoBehaviour
{
    private Player _player;

    public event UnityAction Droped;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out OreUnloadingPoint oreUnloadingPoint))
        {
            if (_player.IsFull)
            {
                Droped?.Invoke();
            }
        }
    }
}
