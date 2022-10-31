using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(Player))]
public class PlayerWeightIK : MonoBehaviour
{
    [SerializeField] private RigBuilder _rigBuilder;

    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _rigBuilder.enabled = _player.IsFull;
    }
}
