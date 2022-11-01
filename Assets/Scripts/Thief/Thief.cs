using UnityEngine;

public class Thief : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PointDomino pointDomino))
        {
            pointDomino.HideDomino();
        }
    }
}
