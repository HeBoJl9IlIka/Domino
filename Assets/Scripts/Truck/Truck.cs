using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Truck : MonoBehaviour
{
    private const int MaxDistanceX = 78;

    [SerializeField] private AnimationMovingDomino[] _dominos;
    [SerializeField] private int _price;

    public event UnityAction<int> Loaded;

    private void Update()
    {
        if (transform.position.x >= MaxDistanceX)
        {
            foreach (var domino in _dominos)
                domino.gameObject.SetActive(false);

            gameObject.SetActive(false);
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (player.IsFull == false)
                return;

            AnimationMovingDomino domino = _dominos.FirstOrDefault(domino => domino.gameObject.activeSelf == false);

            if(domino != null)
            {
                domino.gameObject.SetActive(true);
                Loaded?.Invoke(_price);
            }
        }
    }
}
