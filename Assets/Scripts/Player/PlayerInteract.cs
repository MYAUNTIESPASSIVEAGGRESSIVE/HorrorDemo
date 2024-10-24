using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("References")]
    public GameObject Camera;

    [Header("Interaction Variables")]
    public LayerMask InteractableLayer;
    public float RayLength = 10f;
    private bool ViewingDocument;

    private void Start()
    {
        ViewingDocument = false;
    }

    void Update()
    {
        RaycastHit hitobject;

        if (Physics.Raycast(Camera.transform.position, Camera.transform.TransformDirection(Vector3.forward), out hitobject, RayLength, InteractableLayer))
        {
            ShowTooltip();

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hitobject.transform.CompareTag("Document")) ViewingDocument = true;



            }
            if (Input.GetKeyDown(KeyCode.Tab) && ViewingDocument)
            {

            }
        }
    }

    private void ShowTooltip()
    {
        
    }
}
