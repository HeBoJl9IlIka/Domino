using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Data))]
public class CheckingFirstStart : MonoBehaviour
{
    [SerializeField] private Manual _manual;
    [SerializeField] private GameObject _arrow;

    private Data _data;

    public event UnityAction Started;

    private void Awake()
    {
        _data = GetComponent<Data>();

        if (_data.IsFirstStart == false)
        {
            _manual.gameObject.SetActive(false);
            _arrow.gameObject.SetActive(false);
        }

        Started?.Invoke();
    }
}
