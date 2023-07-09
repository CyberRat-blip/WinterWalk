//using UnityEngine;
//using UnityEngine.UI;

//public class CheckMainQuestButton : MonoBehaviour
//{
//    public InventoryManager inventoryManager;
//    public Text resultText;

//    private void Start()
//    {
//        Button button = GetComponent<Button>();
//        button.onClick.AddListener(CheckMainQuest);
//    }

//    private void CheckMainQuest()
//    {
//        //bool isValid = inventoryManager.AreMainQuestItemsValid();

//       // if (isValid)
//        {
//            resultText.text = "Main quest items are valid!";
//        }
//        else
//        {
//            resultText.text = "Main quest items are not valid!";
//        }
//    }
//}