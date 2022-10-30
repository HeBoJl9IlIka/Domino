using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckLoadingDomino : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PointDomino pointDomino))
        {
            //if (_player.IsFull)
            //{
            //    //Droped?.Invoke();
            //    //_dominoPlace.ShowDomino();
            //}
        }
    }
}
