using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCanvasScript : MonoBehaviour
{
    [Header("UI References")]
    public PlayerControl PlayerScript;
    public Canvas InventoryCanvas;
    public Image SlotHolder;

    [Header("Inventory References")]
    public GameObject Slots;
    public List<SlotScript> InventorySlots = new List<SlotScript>(12);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerScript.Paused = false;
            InventoryCanvas.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    private void UpdateInventory()
    {

        foreach(Transform Children in SlotHolder.transform)
        {
            Destroy(Children.gameObject);
        }
        InventorySlots = new List<SlotScript>(12);
    }


    public void CreateInventory(List<InventoryItemData> Inventory)
    {
        
        UpdateInventory();

        for (int i = 0;  i < InventorySlots.Capacity; i++)
        {
            AddSlot();
        }

        for(int i = 0; i < Inventory.Count; i++)
        {
            InventorySlots[i].CreateSlot(Inventory[i]);
        }
    }

    public void AddSlot()
    {
        
        GameObject AddedSlot = Instantiate(Slots);
        AddedSlot.transform.SetParent(SlotHolder.transform, false);

        SlotScript slotScript = AddedSlot.GetComponent<SlotScript>();
        slotScript.EmptySlot();

        InventorySlots.Add(slotScript);
    }
}
