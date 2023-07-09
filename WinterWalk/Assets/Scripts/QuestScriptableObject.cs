using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class QuestScriptableObject : ScriptableObject
{
    public enum QuestType {First, Twice}
    public QuestType questType;
    public ItemScriptableObject finalQuest;
    public int questAmount;
    public List<QuestResource> questResources;

}
[System.Serializable]
public class QuestResource
{
    public ItemScriptableObject questObject;
    public int questObjectAmount;
}

