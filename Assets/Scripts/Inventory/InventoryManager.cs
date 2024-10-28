using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItemData> InvItems;

    public Dictionary<SO_InventoryItems, InventoryItemData> InvObjects;

    public static InventoryManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        
    }

    public void Add(SO_InventoryItems SOitem)
    {
        if (InvObjects.TryGetValue(SOitem, out InventoryItemData item))
        {
            InventoryItemData addObj = new InventoryItemData(SOitem);
            InvItems.Add(addObj);
        }
    }
}
