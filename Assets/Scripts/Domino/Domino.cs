using UnityEngine;

[RequireComponent(typeof(AnimationMovingDomino))]
public class Domino : MonoBehaviour
{
    private AnimationMovingDomino _animationMovingDomino;

    private void OnDisable()
    {
        _animationMovingDomino.enabled = true;
    }
}
