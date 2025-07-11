using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class InventoryItemSO : ScriptableObject
{

    // will hold the data for my items in the game the player can get

    public string itemName;
    public Sprite icon;
    public bool isKeyItem;
    public string itemId;
}
