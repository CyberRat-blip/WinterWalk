//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerDamageScript : MonoBehaviour
//{
//    public int meleDamageAmount = 20;
//    public static Collider onColliderSwitch;

//    private void Start()
//    {
//        onColliderSwitch = GetComponent<Collider>();
//    }
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.tag == "Enemy")
//        {
//            other.GetComponent<EnemyScript>().TakeDamage(meleDamageAmount);
//        }
//    }
//    public static void deathCollider(bool switcher)
//    {
//        onColliderSwitch.enabled = switcher;
//    }

    //
    //{
    //    if (other.tag == "Player")
    //    {
    //        other.GetComponent<Indicators>().TakeDamage(damageCount);
    //    }
    //}
//}
