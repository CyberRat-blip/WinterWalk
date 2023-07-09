using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIBG;
    public Transform inventoryPanel;
    public Transform quickslotPanel;
    public Transform mainQuestPanel;
    public Transform allMainQuestPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpenedd;
    public GameObject questPanel;
    public GameObject completedPanel;
    private bool keyUpTrigger;
    private QuestManager questManager;
    public List<ItemScriptableObject> mainQuestItems = new List<ItemScriptableObject>();
    public List<ItemScriptableObject> expectedItems = new List<ItemScriptableObject>(); // Список ожидаемых предметов
    float timer;


    // Start is called before the first frame update
    private void Awake()
    {
        allMainQuestPanel.gameObject.SetActive(true);
        // Добавление объектов в первые 4 слота mainQuestPanel
        for (int i = 0; i < mainQuestItems.Count; i++)
        {
            if (i < 4)
            {
                InventorySlot slot = mainQuestPanel.GetChild(i).GetComponent<InventorySlot>();
                if (slot != null)
                {
                    slot.item = mainQuestItems[i];
                    slot.amount = 1;
                    slot.isEmpty = false;
                    slot.SetIcon(mainQuestItems[i].icon);
                    slot.itemAmountText.text = "1";
                }
            }
            else
            {
                Debug.LogWarning("Not enough slots in mainQuestPanel for mainQuestItems.");
                break;
            }
        }
        
    }
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();

        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            InventorySlot slot = inventoryPanel.GetChild(i).GetComponent<InventorySlot>();
            if (slot != null)
            {
                slots.Add(slot);
            }
        }

        for (int i = 0; i < quickslotPanel.childCount; i++)
        {
            InventorySlot slot = quickslotPanel.GetChild(i).GetComponent<InventorySlot>();
            if (slot != null)
            {
                slots.Add(slot);
            }
        }

        for (int i = 0; i < mainQuestPanel.childCount; i++)
        {
            InventorySlot slot = mainQuestPanel.GetChild(i).GetComponent<InventorySlot>();
            if (slot != null)
            {
                slots.Add(slot);
            }
        }

        UIBG.SetActive(false);
        inventoryPanel.gameObject.SetActive(false);
        questPanel.gameObject.SetActive(false);
        allMainQuestPanel.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpenedd = !isOpenedd;
            questPanel.gameObject.SetActive(false);
            allMainQuestPanel.gameObject.SetActive(false);
            questManager.isOpened = false;
            questManager.isOpeneddd = false;
            if (isOpenedd)
            {
                UIBG.SetActive(true);
                inventoryPanel.gameObject.SetActive(true);
            }
            else
            {
                UIBG.SetActive(false);
                inventoryPanel.gameObject.SetActive(false);
            }
        }

        //if (Input.GetKeyDown(KeyCode.H))
        //{
            
        
    }

    void OnTriggerStay(Collider other)
    {
        // Проверка на наличие предмета
        if (other.GetComponent<Item>() != null && other.gameObject.layer == 3)
        {
            AddItem(other.GetComponent<Item>().item, other.GetComponent<Item>().amount);
            Destroy(other.gameObject);
        }
    }
    public void CheckMainQuestItemsButton()
    {
        if (CheckMainQuestItems())
        {
            timer = 0;
            timer += Time.deltaTime;
            completedPanel.SetActive(true);
            UIBG.SetActive(false);
            allMainQuestPanel.gameObject.SetActive(false);
            if (timer >= 5)
            {
                completedPanel.SetActive(false);
            }
        }
    }
    public void AddItem(ItemScriptableObject item, int amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == item)
            {
                if (slot.amount + amount <= item.maximumAmount)
                {
                    slot.amount += amount;
                    slot.itemAmountText.text = slot.amount.ToString();
                    return;
                }
                break;
            }
        }

        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.item = item;
                slot.amount = amount;
                slot.isEmpty = false;
                slot.SetIcon(item.icon);
                slot.itemAmountText.text = amount.ToString();
                break;
            }
        }

        questManager.currentQuestItem.FillItemDetails();
    }

    public bool CheckMainQuestItems()
    {

        for (int i = 4; i < mainQuestPanel.childCount; i++) // Проверка слотов 5-8
        {
            InventorySlot slot = mainQuestPanel.GetChild(i).GetComponent<InventorySlot>();

            if (slot.isEmpty || slot.item != expectedItems[i - 4])
            {
                return false;
            }
        }

        return true;
    }
}