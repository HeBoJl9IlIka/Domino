using UnityEngine;

public class Gift : MonoBehaviour
{
    [SerializeField] private RectTransform _ads;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            _ads.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
