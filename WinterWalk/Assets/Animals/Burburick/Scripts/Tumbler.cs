using UnityEngine;

public class Tumbler : MonoBehaviour
{
    [SerializeField] private Behaviour ScriptOne;
    [SerializeField] private Behaviour ScriptTwo;
    
    private void Awake()
    {
        
        ScriptOne.enabled = true;
        ScriptTwo.enabled = false;
        
    }
    public void Update()
    {
        ScriptSettings();
    }
    private void ScriptSettings()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ScriptOne.enabled = false;
            ScriptTwo.enabled = true;
            
        }
        
    }
}