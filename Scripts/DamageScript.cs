using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int damageCount = 10;
    public static Collider onColliderSwitch;

    private void Start()
    {
        onColliderSwitch = GetComponent<Collider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Indicators.TakeDamage(damageCount);
    }
    public static void deathCollider(bool switcher)
    {
        onColliderSwitch.enabled = switcher;
    }
    
    //private void OnTriggerEnter(Collider )
    //{
    //    if (other.tag == "Player")
    //    {
    //        other.GetComponent<Indicators>().TakeDamage(damageCount);
    //    }
    //}
}
