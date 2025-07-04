using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private InventoryModel model;
    public InventoryUI view;

    private void Awake()
    {
        model = new InventoryModel();
    }

    public void CollectItem(InventoryItemSO item)
    {
        model.AddItem(item);
        view.Display(model.GetItems());
    }

    public bool HasItem(string itemId)
    {
        return model.HasItem(itemId);
    }

    public InventoryModel GetModel()
    {
        return model;
    }
}
