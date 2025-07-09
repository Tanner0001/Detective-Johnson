using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public InventoryItemSO item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered ");

        var controller = other.GetComponent<InventoryController>();
        if (controller != null)
        {
            controller.CollectItem(item);
            Destroy(gameObject);
        }
    }

}


