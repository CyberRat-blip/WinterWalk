using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public static bool switcher = false;
    private int HP = 100;
    public Animator animator;
    public Slider healthBar;
    

    void Update()
    {
        healthBar.value = HP;
    }

    public void TakeDamage(int meleDamageAmount)
    {
        HP -= meleDamageAmount;
        if (HP <= 0)
        {
            animator.SetTrigger("isDeath");
            GetComponent<Collider>().enabled = false;

        }
        else
            animator.SetTrigger("isDamage");

    }
}
