using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{

    // in here we are setting the UI for the inventory, we have a couple variables, such as the parent containter then we have the prefab item i made that will then get showin in the inventory here
   // should have expanded to inculded showing item speic info such as the number of items in the inventory 
    public Transform slotParent;
    public GameObject slotPrefab;

    public void Display(List<InventoryItemSO> items)
    {
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in items)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            slot.GetComponent<Image>().sprite = item.icon;
            slot.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = item.itemName;
        }
    }


}
