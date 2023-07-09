using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VisibleScript : MonoBehaviour
{
    public static SkinnedMeshRenderer onMeshSwitch;
    
    // Start is called before the first frame update
    void Start()
    {
        onMeshSwitch = GetComponent<SkinnedMeshRenderer>();
    }
    private void Update()
    {
       
    }

    // Update is called once per frame
    public static void fallTree(bool switchVisible)
    {
        
        onMeshSwitch.enabled = switchVisible;
    }
}
