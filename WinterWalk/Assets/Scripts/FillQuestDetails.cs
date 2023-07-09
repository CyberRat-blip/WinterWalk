//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FillQuestDetails : MonoBehaviour
//{
//   // public CraftScriptableObject currentCraftItem;
//    private CraftManager craftManager;
//    public GameObject craftResourcePrefab;
//    public string craftInfoPanelName;

//    private void Start()
//    {
//        craftManager = FindObjectOfType<CraftManager>();
//    }
    //public void FillItemDetails()
    //{
    //    for (int i = 0; i < GameObject.Find(craftInfoPanelName).transform.childCount; i++)
    //    {
    //        Destroy(GameObject.Find(craftInfoPanelName).transform.GetChild(i).gameObject);
    //    }

        //craftManager.craftItemName.text = currentCraftItem.finalCraft.name;
        //craftManager.craftItemDescription.text = currentCraftItem.finalCraft.itemDescription;
        //craftManager.craftItemImage.sprite = currentCraftItem.finalCraft.icon;
        //craftManager.craftItemDuration.text = currentCraftItem.craftTime.ToString();
        //craftManager.craftItemAmount.text = currentCraftItem.craftAmount.ToString();

      //  for (int i = 0; i < currentCraftItem.craftResources.Count; i++)
      //  {
       //     GameObject craftResourceGO = Instantiate(craftResourcePrefab, GameObject.Find(craftInfoPanelName).transform);
            //CraftResourceDetails crd = craftResourceGO.GetComponent<CraftResourceDetails>();
            //crd.amountText.text = currentCraftItem.craftResources[i].craftObjectAmount.ToString();
            //crd.itemTypeText.text = currentCraftItem.craftResources[i].craftObject.itemName;
            //crd.totalText.text = currentCraftItem.craftResources[i].craftObjectAmount.ToString();
       //     int resourceAmount = 0;
        //    foreach (InventorySlot slot in FindObjectsOfType<InventoryManager>()[0].slots)
        //    {
        //        if (slot.isEmpty)
        //            continue;
        //        if (slot.item.itemName == currentCraftItem.craftResources[i].craftObject.itemName)
        //        {
        //            resourceAmount += slot.amount;
        //        }
        //    }
        //    crd.haveText.text = resourceAmount.ToString();
        //}
    //}
//}
