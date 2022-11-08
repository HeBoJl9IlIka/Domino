using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(Thief))]
public class ThiefWeightIK : MonoBehaviour
{
    [SerializeField] private RigBuilder _rigBuilder;

    private Thief _thief;

    private void Start()
    {
        _thief = GetComponent<Thief>();
    }

    private void Update()
    {
        _rigBuilder.enabled = _thief.IsTookDomino;
    }
}
