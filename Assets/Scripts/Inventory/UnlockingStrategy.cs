using UnityEngine;

public class KeyUnlockStrategy : IDoorUnlockStrategy
{

    // in this we have a couple things we are doingm, first we have to get the id of the key/item we are holding/using
    // we will need to check if the door can be unlocked using said item in our bool function
    private string requiredKeyId;

    public KeyUnlockStrategy(string keyId)
    {
        requiredKeyId = keyId;
    }

    public bool CanUnlock(InventoryModel inventory)
    {
        return inventory.HasItem(requiredKeyId);
    }
}
