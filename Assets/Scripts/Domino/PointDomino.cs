using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class PointDomino : MonoBehaviour
{
    [SerializeField] private GameObject _pointer;
    [SerializeField] private GameObject _domino;
    [SerializeField] private ParticleSystem _dust;
    [SerializeField] private ParticleSystem _money;
    [SerializeField] private int _price;

    private BoxCollider _boxCollider;

    public bool IsActive { get; private set; }
    public bool IsIndicates { get; private set; }

    public event UnityAction<int> Showed;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _boxCollider.enabled = false;

        if (_domino.activeSelf)
            IsActive = true;
    }

    public void ShowPointer()
    {
        IsIndicates = true;
        _boxCollider.enabled = true;
        _pointer.SetActive(true);
    }

    public void ShowDomino()
    {
        IsIndicates = false;
        _boxCollider.enabled = false;
        IsActive = true;
        _dust.Play();
        _money.Play();
        _pointer.SetActive(false);
        _domino.SetActive(true);
        Showed?.Invoke(_price);
    }
    
    public void HideDomino()
    {
        IsActive = false;
        _pointer.SetActive(false);
        _domino.SetActive(false);
    }

    public void HidePointer()
    {
        _pointer.SetActive(false);
    }
}
