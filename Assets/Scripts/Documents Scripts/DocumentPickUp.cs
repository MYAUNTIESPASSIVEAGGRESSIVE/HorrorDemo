using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DocumentPickUp : MonoBehaviour
{
    public SO_Documents Document;
    public GameObject PickupObject;

    public TMP_Text WrittenText;
    public TMP_Text ClearText;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Document.DocumentBackground;


    }

    private void Update()
    {

    }
}
