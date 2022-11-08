using UnityEngine;

public class ArrowThiefDirection : MonoBehaviour
{
    [SerializeField] private Thief _thief;

    private void Update()
    {
        Vector3 targetPostition = new Vector3(_thief.transform.position.x, this.transform.position.y, _thief.transform.position.z);
        this.transform.LookAt(targetPostition);
    }
}
