using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillQuestDetails : MonoBehaviour
{
    private QuestManager questManager;
    public QuestScriptableObject currentQuestItem;
    private InventoryManager inventoryManager;
    private GameObject questInfoPanelGO;
    public GameObject questResourcePrefab;
    private GameObject buttonFinalQuest;
    //public string completedQuestButton;
    public string detailsQuestInfoPanelName;
    public GameObject questTest;
    public void Awake()
    {
        questManager = FindObjectOfType<QuestManager>();
       // questManager.detailsGroupItem.gameObject.SetActive(true);
        questInfoPanelGO = GameObject.Find(detailsQuestInfoPanelName);
        //buttonFinalQuest = GameObject.Find(completedQuestButton);
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    public void FillItemDetails()
    {
        questManager.detailsGroupItem.gameObject.SetActive(true);
        // questManager.questDetailsPanel.gameObject.SetActive(true);
        questManager.currentQuestItem = this;
        //questManager.detailsGroupItem.gameObject.SetActive(true);
        GameObject buttomToCompletedQuest = buttonFinalQuest;
       
        for (int i = 0; i < questTest.transform.childCount; i++)
        {
            Destroy(questTest.transform.GetChild(i).gameObject);
        }

        bool canCraft = true;
       
                for (int i = 0; i < currentQuestItem.questResources.Count; i++)
                {
                    GameObject questResourceGO = Instantiate(questResourcePrefab, questTest.transform);
                    QuestResoursDetails qrd = questResourceGO.GetComponent<QuestResoursDetails>();
                    int amountRes = currentQuestItem.questResources[i].questObjectAmount;
                    qrd.amountText.text = amountRes.ToString();
                    qrd.itemTypeText.text = currentQuestItem.questResources[i].questObject.itemName;
                    int resourceHave = 0;
                    foreach (InventorySlot slot in FindObjectsOfType<InventoryManager>()[0].slots)
                    {
                        if (slot.isEmpty)
                            continue;
                        if (slot.item.itemName == currentQuestItem.questResources[i].questObject.itemName)
                        {
                            resourceHave += slot.amount;
                        }
                    }
                    qrd.haveText.text = resourceHave.ToString();

                    if (resourceHave < amountRes)
                    {
                        canCraft = false;
                    }
                }
            
        
        if (canCraft)
        {
            questManager.butnQuestSuc.interactable = true;
        }
        else
        {
            questManager.butnQuestSuc.interactable = false;
        }
    }

    public void QuestCompleted()
    {
        foreach (QuestResource questResource in currentQuestItem.questResources)
        {
            int amountToRemove = questResource.questObjectAmount;
            foreach (InventorySlot slot in inventoryManager.slots)
            {
                if (amountToRemove <= 0)
                    continue;
                if (slot.item == questResource.questObject)
                {
                    if (amountToRemove > slot.amount)
                    {
                        amountToRemove -= slot.amount;
                        slot.GetComponentInChildren<DragAndDropItem>().NullifySlotData();
                    }
                    else
                    {
                        slot.amount -= amountToRemove;
                        amountToRemove = 0;
                        if (slot.amount <= 0)
                        {
                            slot.GetComponentInChildren<DragAndDropItem>().NullifySlotData();
                        }
                        else
                        {
                            slot.itemAmountText.text = slot.amount.ToString();
                        }
                    }
                }
            }
        }
    
        inventoryManager.AddItem(currentQuestItem.finalQuest, currentQuestItem.questAmount);
        FillItemDetails();
    }
}
