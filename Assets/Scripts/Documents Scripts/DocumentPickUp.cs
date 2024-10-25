using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DocumentPickUp : MonoBehaviour
{
    public PlayerControl PlayerMovement;
    public GameObject PickupObject;
    public GameObject ReadHolder;
    public GameObject ClearVersionCanvas;

    public TMP_Text WrittenText;
    public TMP_Text ClearText;

    public void OnObjectPickedUp()
    {
        PickupObject.transform.position = ReadHolder.transform.position;
    }

    public void ShowClearVersion()
    {
        ClearText.text = WrittenText.text;
    }
}
