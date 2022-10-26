using UnityEngine;

public class ArrowDirecting : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private DominoPlace _dominoPlace;
    [SerializeField] private Transform _pointTake;
    [SerializeField] private Transform _pointDrop;
    [SerializeField] private Transform _target;
    
    private void Update()
    {
        if(_player.IsFull)
            _target = _dominoPlace.Target;
        else
            _target = _pointTake;

        Vector3 targetPostition = new Vector3(_target.position.x, this.transform.position.y, _target.position.z);
        this.transform.LookAt(targetPostition);
    }
}
