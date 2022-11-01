using UnityEngine;
using UnityEngine.Events;

public class Thief : MonoBehaviour
{
    public event UnityAction Stolen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PointDomino pointDomino))
        {
            pointDomino.HideDomino();
            Stolen?.Invoke();
        }
    }
}
