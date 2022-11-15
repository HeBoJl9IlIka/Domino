using UnityEngine;

public class Domino : MonoBehaviour
{
    private AnimationMovingDomino _animationMovingDomino;

    private void Start()
    {
        if(gameObject.TryGetComponent(out AnimationMovingDomino animationMovingDomino))
            _animationMovingDomino = animationMovingDomino;
    }

    private void OnDisable()
    {
        if(_animationMovingDomino != null)
            _animationMovingDomino.enabled = true;
    }
}
