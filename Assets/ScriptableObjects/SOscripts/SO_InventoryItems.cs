using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Inventory Item", menuName = "Inventory/ Create Inventory Item", order = 1)]
public class SO_InventoryItems : ScriptableObject
{
    public string ItemName;

    public string ItemDescription;

    public Sprite ItemIcon;
}
