using UnityEngine;
using UnityEngine.Events;

public class LastDomino : MonoBehaviour
{
    public event UnityAction Finished;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Domino domino))
            Finished?.Invoke();
    }
}
