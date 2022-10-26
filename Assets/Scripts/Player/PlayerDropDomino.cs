using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerDropDomino : MonoBehaviour
{
    [SerializeField] private DominoPlace _dominoPlace;

    private Player _player;

    public event UnityAction Droped;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PointDomino pointDomino))
        {
            if (_player.IsFull)
            {
                Droped?.Invoke();
                _dominoPlace.ShowDomino();
            }  
        }
    }
}
