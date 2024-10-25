using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> InvItems = new List<GameObject>();
    public List<string> InvCode = new List<string>();

    public Dictionary<string,GameObject> InvObjects = new Dictionary<string,GameObject>();

    public static InventoryManager instance;

    private void Start()
    {


        instance = this;
    }
}
