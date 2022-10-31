using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Truck : MonoBehaviour
{
    [SerializeField] private AnimationMovingDomino[] _domino;
    [SerializeField] private int _price;

    public event UnityAction<int> Loaded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (player.IsFull == false)
                return;

            AnimationMovingDomino domino = _domino.FirstOrDefault(domino => domino.gameObject.activeSelf == false);

            if(domino != null)
            {
                domino.gameObject.SetActive(true);
                Loaded?.Invoke(_price);
            }
        }
    }
}
