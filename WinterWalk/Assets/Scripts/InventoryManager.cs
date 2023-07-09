using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIBG;
    public Transform inventoryPanel;
    public Transform quickslotPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpenedd;
    public GameObject questPanel;
    private bool keyUpTrigger;
    private QuestManager questManager;
    // Start is called before the first frame update
  
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        for (int i = 0; i < quickslotPanel.childCount; i++)
        {
            if (quickslotPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(quickslotPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        UIBG.SetActive(false);
        inventoryPanel.gameObject.SetActive(false);
        questPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpenedd = !isOpenedd;
            questPanel.gameObject.SetActive(false);
            questManager.isOpened = false;
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
        
    }
    
    void OnTriggerStay(Collider other)
    {    
     //Проверка на наличие предмета
        if (other.GetComponent<Collider>().gameObject.GetComponent<Item>() != null && other.gameObject.layer == 3)
         {
           AddItem(other.GetComponent<Collider>().gameObject.GetComponent<Item>().item, other.GetComponent<Collider>().gameObject.GetComponent<Item>().amount);          
           Destroy(other.GetComponent<Collider>().gameObject);
        }
            
    }

    public void AddItem(ItemScriptableObject _item, int _amount)
    {
        
        foreach (InventorySlot slot in slots)
        {
            // В слоте уже имеется этот предмет
            if (slot.item == _item)
            {
                if (slot.amount + _amount <= _item.maximumAmount)
                {
                    slot.amount += _amount;
                    slot.itemAmountText.text = slot.amount.ToString();
                    return;
                }
                break;
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                if (slot.item.maximumAmount != 1)
                {
                    slot.itemAmountText.text = _amount.ToString();
                }
                break;
            }
        }
        questManager.currentQuestItem.FillItemDetails();

    }
}
