using System.Linq;
using UnityEngine;

public class ThiefPickDomino : MonoBehaviour
{
    [SerializeField] private Domino[] _dominos;

    public bool TryGetActiveDomino(out Domino domino)
    {
        domino = _dominos.FirstOrDefault(domino => domino.gameObject.activeSelf == true);
        return domino != null;
    }
}
