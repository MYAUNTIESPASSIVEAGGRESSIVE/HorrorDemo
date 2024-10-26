using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interactable interface that allows for multiple objects to call different actions on interaction.
interface IInteractable
{
    public void OnInteract(){}
}

public class PlayerInteract : MonoBehaviour
{
    [Header("References")]
    public GameObject Camera;
    public PlayerControl PlayerScript;

    [Header("Interaction Variables")]
    public LayerMask InteractableLayer;
    public float RayLength = 10f;
    private RaycastHit hitobject;

    private void Start()
    {

    }

    // raycast which checks for the interactable layer 
    void Update()
    {

        if (Physics.Raycast(Camera.transform.position, Camera.transform.TransformDirection(Vector3.forward), 
            out hitobject, RayLength, InteractableLayer))
        {
            // show the appropriate tooltip
            ShowTooltip();

            // selection key and cheks for interactable interface which then calls the on interact
            if (Input.GetKeyDown(KeyCode.E) && 
                hitobject.collider.gameObject.TryGetComponent(out IInteractable interactobj))
            {
                PlayerScript.LookingAtItem = true;
                interactobj.OnInteract();
            }
        }
    }

    // function which changes the tooltip canvas text to match the object
    private void ShowTooltip()
    {
        
    }
}
