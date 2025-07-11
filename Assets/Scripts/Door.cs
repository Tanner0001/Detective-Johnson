using UnityEngine;

public class Door : MonoBehaviour, IUsable
{
    public string requiredKeyId;
    private IDoorUnlockStrategy unlockStrategy;
    private bool isOpen = false;

    private void Start()
    {
        unlockStrategy = new KeyUnlockStrategy(requiredKeyId);
    }

    public void Use(GameObject user)
    {
        InventoryService inventory = InventoryService.Instance;
        if (inventory != null)
        {
            TryUnlock(inventory);
        }
    }

    public void TryUnlock(InventoryService inventory)
    {
 

        if (isOpen) return;

        if (unlockStrategy.CanUnlock(inventory.GetModel()))
        {
            Debug.Log("Door unlocked maybe");
            OpenDoor();
        }
        else
        {
            // would tell you cant 
        }
    }


    private void OpenDoor()
    {
        isOpen = true;
        gameObject.SetActive(false);
    }
}
