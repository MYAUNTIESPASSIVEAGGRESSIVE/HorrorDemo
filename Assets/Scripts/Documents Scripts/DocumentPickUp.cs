using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;
using System;
using JetBrains.Annotations;

public class DocumentPickUp : MonoBehaviour, IInteractable
{
    [Header("References")]
    public GameObject PickupObject;
    public GameObject ReadHolder;
    public GameObject ClearVersionCanvas;
    public SO_InventoryItems Document;
    public PlayerControl PlayerScript;

    [Header("Text References")]
    public TMP_Text WrittenText;
    public TMP_Text ClearText;
    public TMP_Text ControlsText;

    private bool ClearShow;
    private bool ViewingDocument;

    // event which uses the pickups SO and add it to the inventory
    public static event Action<SO_InventoryItems> AddToInventory;

    public void OnInteract()
    {
        // document is moved in front of the player and is now readable
        PickupObject.transform.position = ReadHolder.transform.position;

        ControlsText.gameObject.SetActive(true);

        ViewingDocument = true;

    }


    private void ShowClearVersion()
    {
        // the clear text is now the same as the written text on the document and the clear canvas is enabled
        ClearText.text = WrittenText.text;

        ClearVersionCanvas.SetActive(true);
    }

    void Update()
    {
        if (ViewingDocument)
        {
            // when tab is pressed then the clear version of the document is now visable
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ClearShow = !ClearShow;
                // if the clear version is shown then function is enabled
                if (ClearShow) ShowClearVersion(); else ClearVersionCanvas.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //adds item to the inventory on exit + destroys the document
                AddToInventory?.Invoke(Document);
                Destroy(gameObject);
                // sets viewing booleans inactive + any game objects false
                ControlsText.gameObject.SetActive(false);
                ClearVersionCanvas.SetActive(false);
                PlayerScript.LookingAtItem = false;
                ViewingDocument = false;
            }
        }
    }
}
