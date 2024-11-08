using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;

interface IUnlockable
{
    public void Unlock();
}

public class KeyPadScript : MonoBehaviour, IInteractable
{
    [Header("References")]
    public GameObject Player;
    public Transform ViewingSpot;
    public Transform CamHolder;
    public TMP_Text ScreenString;

    public Transform OGCamSpot;

    public GameObject UnlockableObject;

    [Header("Variables")]
    public string AnswerString;
    public int ButtonNumber;

    private bool ViewingObject;

    private bool AnswerSolved;

    public void Start()
    {
        OGCamSpot.transform.position = CamHolder.transform.position;
        OGCamSpot.transform.rotation = CamHolder.transform.rotation;
    }

    public void OnInteract()
    {
        Player.GetComponent<PlayerControl>().Paused = true;
        CamHolder.transform.position = ViewingSpot.transform.position;
        CamHolder.transform.rotation = Quaternion.Slerp(CamHolder.transform.rotation, ViewingSpot.transform.rotation, 1f);
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
                CamHolder.transform.position = OGCamSpot.transform.position;
                CamHolder.transform.rotation = Quaternion.Slerp(CamHolder.transform.rotation, OGCamSpot.transform.rotation, 1f);

                //Setting player movement bools and crosshair active again.
                Player.GetComponent<PlayerControl>().Paused = false;
                Player.GetComponent<PlayerControl>().LookingAtItem = false;
                Player.GetComponent<PlayerInteract>().Crosshair.SetActive(true);
                ViewingObject = false;
                Cursor.lockState = CursorLockMode.Locked;
                gameObject.GetComponent<BoxCollider>().enabled = true;
            }
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

            AnswerSolved = true;

            if (UnlockableObject.TryGetComponent(out IUnlockable UnlockableObj))
            {
                UnlockableObj.Unlock();
            }
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
        if (!AnswerSolved)
        {
            ScreenString.text = ScreenString.text.Remove(ScreenString.text.Length - 1);
        }
        else return;
    }
}
