using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour, IInteractable
{
    public Transform DoorHinge;
    public AudioSource DoorSource;

    public void OnInteract()
    {
        DoorSource.Play();
        DoorHinge.Rotate(0,90,0);
    }
}
