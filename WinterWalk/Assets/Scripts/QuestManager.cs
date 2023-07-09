using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    public bool isOpened;
    public GameObject detailsGroupItem;
    //public GameObject questDetailsPanel;
    public GameObject questPanel;
    public GameObject buttonPanel;
    public GameObject buttonPanell;
    public GameObject complButtonPanell;
    public GameObject descriptionPanel;
    public Transform infoPanel;
    public GameObject buttonNext;
    public GameObject descText;
    public GameObject UIBG;
    public Transform questInfoPanel;
    public Button butnQuestSuc;
    public FillQuestDetails currentQuestItem;
    public Transform inventoryPanel;
    public InventoryManager inventoryManager;
    public KeyCode openCloseCraftButton;
    public List<QuestScriptableObject> allQuests;
    [Header("Quest Item Details")]
    public TMP_Text questItemName;
    public TMP_Text questItemAmount;

    private void Awake()
    {
        //GameObject questItemButtonPanel = Instantiate(buttonPanel, questInfoPanel);
        //questItemButtonPanel.GetComponent<FillQuestDetails>().FillItemDetails();
        //Destroy(questItemButtonPanel);
        
        inventoryManager = FindObjectOfType<InventoryManager>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(openCloseCraftButton))
        {
            isOpened = !isOpened;
            inventoryPanel.gameObject.SetActive(false);
            inventoryManager.isOpenedd = false;
            if (isOpened)
            {
                questPanel.SetActive(true);
                UIBG.SetActive(true);
                detailsGroupItem.gameObject.SetActive(false);
            }
            else
            {
                questPanel.SetActive(false);
                UIBG.SetActive(false);
            }
        }
    }
    public void LoadQuestItems(string questType)
    {
        //detailsGroupItem.gameObject.SetActive(false);
        //questDetailsPanel.gameObject.SetActive(false);
        for (int i = 0; i < questInfoPanel.childCount; i++)
        {
            Destroy(questInfoPanel.GetChild(i).gameObject);
        }
        
        for (int i = 0; i < infoPanel.childCount; i++)
        {
            Destroy(infoPanel.GetChild(i).gameObject);
        }
        foreach (QuestScriptableObject qso in allQuests)
        {
            if (qso.questType.ToString().ToLower() == questType.ToLower())
            {
                GameObject questItemButtonPanel = Instantiate(buttonPanel, questInfoPanel);
                GameObject questItemButtonPanel1 = Instantiate(buttonPanell, questInfoPanel);
                GameObject questItemButtonPanel2 = Instantiate(descriptionPanel, infoPanel);
                GameObject questItemButtonPanel3 = complButtonPanell;
                questItemButtonPanel2.GetComponent<TextMeshProUGUI>().text = qso.finalQuest.itemDescription;
                questItemButtonPanel.GetComponent<FillQuestDetails>().currentQuestItem = qso;
                questItemButtonPanel3.GetComponent<FillQuestDetails>().currentQuestItem = qso;
            }

        }
    } 
}
