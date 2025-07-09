using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public InventoryItemSO item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.name);

        var controller = other.GetComponent<InventoryController>();
        if (controller != null)
        {
            Debug.Log("Item should be picked up");
            controller.CollectItem(item);
            Destroy(gameObject);
        }
    }

}


