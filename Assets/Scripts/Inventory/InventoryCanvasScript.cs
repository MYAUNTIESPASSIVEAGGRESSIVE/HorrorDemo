using System.Collections;
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

    private void OnEnable()
    {
        InventoryManager.OnInventoryChanged += CreateInventory;
    }

    private void OnDisable()
    {
        InventoryManager.OnInventoryChanged -= CreateInventory;
    }

    void CreateInventory(List<InventoryItemData> Inventory)
    {
        for (int i = 0;  i < InventorySlots.Capacity; i++)
        {
            AddSlot();
        }

        for(int i = 0; i < Inventory.Count; i++)
        {
            InventorySlots[i].CreateSlot(Inventory[i]);
        }
    }

    void AddSlot()
    {
        GameObject AddedSlot = Instantiate(Slots);
        AddedSlot.transform.SetParent(SlotHolder.transform);

        SlotScript slotScript = AddedSlot.GetComponent<SlotScript>();
        slotScript.EmptySlot();

        InventorySlots.Add(slotScript);
    }
}
