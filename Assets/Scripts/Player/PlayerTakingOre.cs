using UnityEngine;
using UnityEngine.Events;

public class PlayerTakingOre : MonoBehaviour
{
    private Player _player;

    public event UnityAction Taked;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out OreAnimator ore))
        {
            if (_player.IsFull)
                return;

            Taked?.Invoke();
            ore.gameObject.SetActive(false);
            ore.Reset();
        }
    }
}
