using UnityEngine;

public class Door : MonoBehaviour
{
    public string requiredKeyId;
    private IDoorUnlockStrategy unlockStrategy;
    private bool isOpen = false;

    private void Start()
    {
        unlockStrategy = new KeyUnlockStrategy(requiredKeyId);
    }
    // we excute this when a player tries to get in the door, now if they have the key and are in said state it will open if not it will error msg and return
    public void TryUnlock(InventoryModel inventory)
    {
        if (isOpen) return;

        if (unlockStrategy.CanUnlock(inventory))
        {
            OpenDoor();
        }
        else
        {
            Debug.Log("Door is locked. Try looking around for a key");
        }
    }

    private void OpenDoor()
    {
        isOpen = true;
        Debug.Log("Door unlocked");
        // ill have to make it so a door is acutally opening
    }
}
