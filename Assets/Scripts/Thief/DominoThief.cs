using UnityEngine;

public class DominoThief : MonoBehaviour
{
    [SerializeField] private Thief _thief;

    private void OnEnable()
    {
        transform.position = _thief.transform.position;
        //transform.rotation = _thief.transform.rotation;
    }
}
