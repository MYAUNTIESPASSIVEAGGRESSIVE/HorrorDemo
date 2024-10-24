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

    void Update()
    {
        RaycastHit hitobject;

        if (Physics.Raycast(Camera.transform.position, Camera.transform.TransformDirection(Vector3.forward), out hitobject, RayLength, InteractableLayer))
        {
            // show interable tooltip
            // if e is pressed then show the letter or documents or whatnot
            // if f is pressed while the document is up then 
        }
    }
}
