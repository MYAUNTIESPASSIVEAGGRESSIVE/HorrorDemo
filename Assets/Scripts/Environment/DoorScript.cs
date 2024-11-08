using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour, IUnlockable
{
    public Transform Hinge;
    public AudioSource DoorSource;

    public void Unlock()
    {
        DoorSource.Play();
        Hinge.Rotate(0, 90, 0);
    }
}
