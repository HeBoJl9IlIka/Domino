using System.Linq;
using UnityEngine;

public class ThiefPickDomino : MonoBehaviour
{
    [SerializeField] private Domino[] _dominos;

    public bool TryGetActiveDomino(out Domino domino)
    {
        domino = _dominos.FirstOrDefault(domino => domino.gameObject.activeSelf == true);

        if (domino.GetComponentInParent<PointDomino>().TryGetComponent(out BoxCollider boxCollider))
            boxCollider.enabled = true;

        return domino && boxCollider != null;
    }
}
