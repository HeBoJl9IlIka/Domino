using UnityEngine;

public class OreDumpingTransition : Transition
{
    [SerializeField] private OreCollectionState _oreCollectionState;

    private void Update()
    {
        NeedTransit = _oreCollectionState.IsReady;
        _oreCollectionState.Reset();
    }
}
