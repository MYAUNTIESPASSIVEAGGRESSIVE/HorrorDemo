using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;
using System;

public class DocumentPickUp : MonoBehaviour, IInteractable
{
    [Header("References")]
    public GameObject PickupObject;
    public GameObject ReadHolder;
    public GameObject ClearVersionCanvas;
    public SO_InventoryItems Document;
    public InventoryManager InvManager;

    [Header("Text References")]
    public TMP_Text WrittenText;
    public TMP_Text ClearText;

    private bool ClearShow;

    public void OnInteract()
    {
        Debug.Log("Interacted");

        PickupObject.transform.position = ReadHolder.transform.position;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ClearShow = !ClearShow;

            if(ClearShow) ShowClearVersion(); else ClearVersionCanvas.SetActive(false);
        }

        if(!ClearShow && Input.GetKeyDown(KeyCode.E))
        {
            // adds the document to the inventory
            InvManager.Add(Document);
        }
    }



    private void ShowClearVersion()
    {
        ClearText.text = WrittenText.text;

        ClearVersionCanvas.SetActive(true);
    }
}
