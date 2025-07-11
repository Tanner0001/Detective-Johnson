using System.Collections.Generic;
using System.Linq;

public class InventoryModel
{
    // all main model of the inventory, adding checking if we have a said item

    // in adddition to the inventory service i could possibly track the dictionary for the quanties of the items instead of it rely on the service
    private List<InventoryItemSO> items = new List<InventoryItemSO>();

    public void AddItem(InventoryItemSO item)
    {
        items.Add(item);
    }

    public bool HasItem(string itemId)
    {
        return items.Any(i => i.itemId == itemId);
    }



    public List<InventoryItemSO> GetItems()
    {
        return new List<InventoryItemSO>(items);
    }
}
