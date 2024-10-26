using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DocumentPickUp : MonoBehaviour, IInteractable
{
    [Header("References")]
    public GameObject PickupObject;
    public GameObject ReadHolder;
    public GameObject ClearVersionCanvas;

    [Header("Text References")]
    public TMP_Text WrittenText;
    public TMP_Text ClearText;

    public void OnInteract()
    {
        PickupObject.transform.position = ReadHolder.transform.position;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ShowClearVersion();
        }
    }

    private void ShowClearVersion()
    {
        ClearText.text = WrittenText.text;

        ClearVersionCanvas.SetActive(true);
    }
}
