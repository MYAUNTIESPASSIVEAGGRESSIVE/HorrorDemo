using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;

public class KeyPadScript : MonoBehaviour, IInteractable
{
    [Header("References")]
    public GameObject Player;
    public Transform MainCam;
    public Transform ViewingSpot;
    public Transform CamHolder;
    public TMP_Text ScreenString;

    [Header("Variables")]
    public string AnswerString;
    public int ButtonNumber;

    private bool ViewingObject;

    void Start()
    {
          
    }

    public void OnInteract()
    {
        MainCam.LookAt(transform.position);
        MainCam.transform.position = ViewingSpot.transform.position;
        Player.GetComponent<PlayerControl>().enabled = false;
        ViewingObject = true;
        Cursor.lockState = CursorLockMode.None;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void Update()
    {
        if (ViewingObject)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MainCam.transform.position = CamHolder.transform.position;
                Player.GetComponent<PlayerControl>().enabled = true;
                Player.GetComponent<PlayerControl>().LookingAtItem = false;
                ViewingObject = false;
                Cursor.lockState = CursorLockMode.Locked;
                gameObject.GetComponent<BoxCollider>().enabled = true;
            }
        }

        if(ScreenString.text == AnswerString)
        {
            //unlock door or other things
        }
    }


    public void AddNumber(int ButtonNumber)
    { 
        if (ScreenString.text.Length >= 4)
        {
            ScreenString.text = ScreenString.text;
        }
        else ScreenString.text += ButtonNumber.ToString();
    }

    public void EnterButton()
    {
        if (ScreenString.text == AnswerString)
        {
            ScreenString.text = "Good Job..";
        }
        else
        {
            ScreenString.text = "Wrong..";
            StartCoroutine(WrongAnswer());
        }
    }

    private IEnumerator WrongAnswer()
    {
        yield return new WaitForSecondsRealtime(1);
        ScreenString.text = "";
    }

    public void ClearNumbers()
    {
        ScreenString.text = "";
    }

    public void DeleteNumber()
    {
        
    }
}
