using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneFirstSelector : TemperatureŅontrol
{
    public int X = 0;
    private Collider TriggerSwitch;
    private void Start()
    {
        var Triggers = TemperatureŅontrol.SwitchersZone;
        TriggerSwitch = GetComponent<Collider>();
    }
    void Update()
    {
        if (SwitchersZone == true)
        {
            X = 1;
            TriggerSwitch.enabled = false;
        }
        else
        {
            X = 2;
            TriggerSwitch.enabled = true;
        }
    }
}
