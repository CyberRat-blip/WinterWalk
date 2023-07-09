using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenZoneFirst : MonoBehaviour
{
    public int NowMoment = 0;
    public Indicators indicators;


  
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            NowMoment = gameObject.layer;
           
            
            
                indicators.isInFrozen = gameObject.layer;
            
        }
    }
}
