using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Interactable interface that allows for multiple objects to call different actions on interaction.
interface IInteractable 
{
    public void OnInteract() {}
}

public class PlayerInteract : MonoBehaviour
{
    [Header("References")]
    public GameObject Camera;
    public PlayerControl PlayerScript;
    public TMP_Text ToolTipText;

    [Header("Interaction Variables")]
    public LayerMask InteractableLayer;
    public float RayLength = 10f;
    public GameObject Crosshair;


    private RaycastHit hitobject;

    private void Start()
    {
        Crosshair.SetActive(true);
    }

    // raycast which checks for the interactable layer 
    void Update()
    {
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, 
            out hitobject, RayLength, InteractableLayer))
        {
            // show the appropriate tooltip
            ShowTooltip();

            if (Input.GetKeyDown(KeyCode.E) && !PlayerScript.LookingAtItem)
            {
                // selection key and cheks for interactable interface which then calls the on interact
                if (hitobject.collider.gameObject.TryGetComponent(out IInteractable interactobj))
                {
                    PlayerScript.LookingAtItem = true;
                    interactobj.OnInteract();

                    Crosshair.SetActive(false);
                }
            }
        }
    }

    // function which changes the tooltip text to match the object
    private void ShowTooltip()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(Camera.transform.position, Camera.transform.forward * RayLength);
    }
}
