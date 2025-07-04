using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
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
