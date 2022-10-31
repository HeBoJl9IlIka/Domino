using UnityEngine;
using UnityEngine.Events;

public class PointDomino : MonoBehaviour
{
    [SerializeField] private GameObject _pointer;
    [SerializeField] private GameObject _domino;
    [SerializeField] private ParticleSystem _dust;
    [SerializeField] private ParticleSystem _money;
    [SerializeField] private int _price;

    public bool IsActive { get; private set; }
    public bool IsIndicates { get; private set; }

    public event UnityAction<int> Showed;

    public void ShowPointer()
    {
        IsIndicates = true;
         _pointer.SetActive(true);
    }

    public void ShowDomino()
    {
        IsIndicates = false;
        IsActive = true;
        _dust.Play();
        _money.Play();
        _pointer.SetActive(false);
        _domino.SetActive(true);
        Showed?.Invoke(_price);
    }
}
