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

        _manual.gameObject.SetActive(_data.IsFirstStart);
        _arrow.gameObject.SetActive(_data.IsFirstStart);

        Started?.Invoke();
    }
}
