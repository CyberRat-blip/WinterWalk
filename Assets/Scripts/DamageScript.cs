using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int damageCount = 10;
   // public Collider onColliderSwitch;


    private void OnCollisionEnter(Collision collision)
    {
        Indicators.TakeDamage(damageCount);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyScript>().TakeDamage(damageCount);
        }
        else if (other.tag == "Tree")
        {
            other.GetComponent<TreeScript>().TakeDamage(damageCount);
        }
    }
}
