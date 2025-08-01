using UnityEngine;

public class Collectable : MonoBehaviour, IUsable
{

    [SerializeField] private InventoryItemSO item;

    public void Use(GameObject user)
    {
        var inventory = InventoryService.Instance;
        if (inventory != null && inventory.CollectItem(item))
        {
            Debug.Log(item.name + " is collected");
            Destroy(gameObject);
        }
        else
        {
            // show a UI message saying too much of said item or the system it self is full
        }
    }



}
