using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
   // private QuestManager questManager;
    private Collider onTriggerSwitch;
    // Start is called before the first frame update
    void Start()
    {
      // questManager = FindObjectOfType<QuestManager>();
        onTriggerSwitch = GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //questManager.currentQuestItem.FillItemDetails();
            onTriggerSwitch.enabled = true;
        }
        if(Input.GetKeyUp(KeyCode.F))
        {
            onTriggerSwitch.enabled = false;
        }
    }
}
