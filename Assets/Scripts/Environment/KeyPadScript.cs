using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class KeyPadScript : MonoBehaviour, IInteractable
{
    public PlayerControl PMovementScript;
    public GameObject MainCam;
    public GameObject ViewingSpot;
    private Transform OGCamPos;

    private bool ViewingObject;

    void Start()
    {
        PMovementScript = GetComponent<PlayerControl>();
        OGCamPos.position = MainCam.transform.position;
    }

    public void OnInteract()
    {
        MainCam.transform.position = ViewingSpot.transform.position;
        PMovementScript.Paused = true;
        ViewingObject = true;
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
            MainCam.transform.position = OGCamPos.position;
            PMovementScript.Paused = false;
            ViewingObject = false;
        }
    }
}
