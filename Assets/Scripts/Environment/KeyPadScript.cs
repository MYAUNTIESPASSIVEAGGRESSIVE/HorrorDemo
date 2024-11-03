using UnityEngine;

public class KeyPadScript : MonoBehaviour, IInteractable
{
    [Header("References")]
    public PlayerControl PMovementScript;
    public Transform MainCam;
    public Transform ViewingSpot;
    public Transform CamHolder;

    private bool ViewingObject;

    void Start()
    {
            
    }

    public void OnInteract()
    {
        MainCam.position = ViewingSpot.position;
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
