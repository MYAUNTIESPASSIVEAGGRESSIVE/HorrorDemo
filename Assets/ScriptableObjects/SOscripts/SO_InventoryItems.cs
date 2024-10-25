using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_InventoryItems : ScriptableObject
{
    public string ItemName;

    public string ItemDescription;

    public Sprite ItemIcon;

    public enum Type
    {
        Document,
        Letter,
        Object,
        Puzzle
    }

    public Type ItemType;
}
