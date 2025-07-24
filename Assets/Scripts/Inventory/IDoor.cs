public interface IDoorUnlockStrategy
{

    // will check agasint the inventory to see if we have said item and if its the right item to open the door

    bool CanUnlock(InventoryModel inventory);
}
