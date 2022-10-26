using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreCollectionTransition : Transition
{
    [SerializeField] private OreDumpingState _oreDumpingState;

    private void Update()
    {
        NeedTransit = _oreDumpingState.IsReady;
        _oreDumpingState.Reset();
    }
}
