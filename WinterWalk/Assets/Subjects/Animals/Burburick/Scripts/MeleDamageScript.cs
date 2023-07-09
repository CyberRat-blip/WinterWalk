using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleDamageScript : MonoBehaviour
{
    public int damageAmount = 20;
    public int treeDamageAmount = 15;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyScript>().TakeDamage(damageAmount);
        }
        else if(other.tag == "Tree")
        {
            other.GetComponent<TreeScript>().TakeDamage(treeDamageAmount);
        }
    }
}
