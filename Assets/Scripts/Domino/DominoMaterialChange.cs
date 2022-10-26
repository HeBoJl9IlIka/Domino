using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class DominoMaterialChange : MonoBehaviour
{
    [SerializeField] private Material _targetMaterial;

    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Domino domino))
            _meshRenderer.material = _targetMaterial;
    }
}
