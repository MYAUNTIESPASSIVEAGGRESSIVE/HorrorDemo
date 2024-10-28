using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItemData
{
    // this script tells the inventory manager what scriptable object is being added to the inventory

    public SO_InventoryItems itemdata;

    public InventoryItemData(SO_InventoryItems item)
    {
        itemdata = item;
    }
}
