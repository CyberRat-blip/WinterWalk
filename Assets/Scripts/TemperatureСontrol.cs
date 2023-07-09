using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureСontrol : MonoBehaviour
{
    public static bool SwitchersZone = false;
    public int NowMoment;
    public Indicators indicators;
    protected void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 0 || other.gameObject.layer == 6)
        {
            NowMoment = other.gameObject.layer;
            indicators.isInFrozen = other.gameObject.layer;
        }
    }
}
