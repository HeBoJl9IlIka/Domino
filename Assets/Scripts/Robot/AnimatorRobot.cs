using UnityEngine;

public class AnimatorRobot : MonoBehaviour
{
    private const string Take = "Take";
    private const string Drop = "Drop";

    [SerializeField] private RobotTakingOre _robotTakingOre;
    [SerializeField] private RobotDropOre _robotDropOre;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _robotTakingOre.Taked += OnTaked;
        _robotDropOre.Droped += OnDroped;
    }

    private void OnDisable()
    {
        _robotTakingOre.Taked -= OnTaked;
        _robotDropOre.Droped -= OnDroped;
    }

    private void OnTaked()
    {
        _animator.SetBool(Take, true);
        _animator.SetBool(Drop, false);
    }

    private void OnDroped()
    {
        _animator.SetBool(Take, false);
        _animator.SetBool(Drop, true);
    }
}
