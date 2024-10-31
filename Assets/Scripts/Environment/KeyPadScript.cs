using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class KeyPadScript : MonoBehaviour, IInteractable
{
    public PlayerControl PMovementScript;
    public GameObject MainCam;
    public GameObject ViewingSpot;
    public GameObject CamHolder;

    private bool ViewingObject;

    void Start()
    {
            
    }

    public void OnInteract()
    {
        MainCam.transform.position = ViewingSpot.transform.position;
        PMovementScript.Paused = true;
        ViewingObject = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void Update()
    {
        if (ViewingObject)
        {
            UsingKeypad();
        }
    }

    private void UsingKeypad()
    {



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            PMovementScript.Paused = false;
            ViewingObject = false;
        }
    }
}
