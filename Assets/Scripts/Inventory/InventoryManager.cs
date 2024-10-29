using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItemData> InvItems;

    private Dictionary<SO_InventoryItems, InventoryItemData> InvObjects;

    public static event Action<List<InventoryItemData>> OnInventoryChanged;

    private void OnEnable()
    {
        DocumentPickUp.AddToInventory += Add;
    }
    private void OnDisable ()
    {
        DocumentPickUp.AddToInventory -= Add;
    }

    public void Add(SO_InventoryItems SOitem)
    {
        InventoryItemData addObj = new InventoryItemData(SOitem);
        InvItems.Add(addObj);

        OnInventoryChanged.Invoke(InvItems);
    }
}
