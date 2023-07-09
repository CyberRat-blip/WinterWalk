using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactreSettings : MonoBehaviour
{
    [SerializeField] private Behaviour ScriptOne;
    [SerializeField] private Behaviour ScriptTwo;
    [SerializeField] private bool ControlAiming = false;
    private Animator animator;
    public GameObject cursor;
   
    void Start()
    {
        ScriptOne.enabled = true;
        ScriptTwo.enabled = false;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        AnimationSettings();
    }

   
    private void AnimationSettings()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ControlAiming = !ControlAiming;
        }

        if (ControlAiming)
        {
            animator.SetBool("Aiming", true);
            ScriptOne.enabled = false;
            ScriptTwo.enabled = true;
            cursor.SetActive(true);
        }
        else
        {
            animator.SetBool("Aiming", false);
            ScriptOne.enabled = true;
            ScriptTwo.enabled = false;
            cursor.SetActive(false);
        }
    }
}
