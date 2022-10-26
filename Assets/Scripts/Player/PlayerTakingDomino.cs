using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerTakingDomino : MonoBehaviour
{
    private Player _player;

    public event UnityAction Taked;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out DominoSpawning domino))
        {
            if (_player.IsFull)
                return;

            Taked?.Invoke();
            domino.gameObject.SetActive(false);
            domino.Reset();
        }
    }
}
