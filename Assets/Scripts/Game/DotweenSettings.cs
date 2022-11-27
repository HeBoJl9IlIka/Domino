using DG.Tweening;
using UnityEngine;

public class DotweenSettings : MonoBehaviour
{
    private void Start()
    {
        DOTween.SetTweensCapacity(500, 250);
    }
}
