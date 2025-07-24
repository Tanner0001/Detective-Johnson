using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryService : MonoBehaviour
{
    public static InventoryService Instance { get; private set; }


    [SerializeField] private InventoryUI view;

    private InventoryModel model;


    public event Action<InventoryItemSO> OnItemAdded;
   // public event Action<Dictionary<InventoryItemSO, int>> OnInventoryUpdated; // this is to hold info for said items such as item amounts etc

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        model = new InventoryModel();

        // one instance for the inventory service.
    }

    /*
    public void CollectItem(InventoryItemSO item)
    {
        model.AddItem(item);
        view.Display(model.GetItems());
    }
    */


    public bool CollectItem(InventoryItemSO item)
    {
        if (model.HasItem(item.itemId))
        {
            //just checking if we have said item already
            return false;
        }

        model.AddItem(item);
        OnItemAdded?.Invoke(item);
        view.Display(model.GetItems());
        Debug.Log("Collected item: " + item.itemId);
        return true;
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


