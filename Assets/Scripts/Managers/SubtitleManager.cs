using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitleManager : MonoBehaviour
{
    [Header("ObjectReferences")]
    public TextMeshProUGUI SubtitleName;
    public TextMeshProUGUI SubtitleText;
    public AudioSource PlayerSource;

    [Header("TypingVariables")]
    public float TypingSpeed = 10;

    // queue for subtitles - not used but a good thing to expand with if used in other games;
    private Queue<string> SubtitleQueue = new Queue<string>();

    // private variables
    private bool NoSubtitles;
    private bool Typing;
    private const float MAXTIME = 0.1f;
    private string CurrentSubtitle;
    private Coroutine TypingCoroutine;

    // Checks the count of the queue
    public void DisplaySubtitle(SO_Dialogue DialougeText)
    {

        if (SubtitleQueue.Count == 0) 
        {
            // if there are subtitles to be written then it starts typing
            if(!NoSubtitles)
            {
                Debug.Log("DoStuffing");
                StartTalking(DialougeText);
            }
            else
            {
                // stops the talking and deactivates the text box
                StopTalking();
                return;
            }
        }

        // ensures the coroutine does to activate whilst typing
        if (!Typing)
        {
            CurrentSubtitle = SubtitleQueue.Dequeue();

            // uses the cirrent subtitle as a parameter
            TypingCoroutine = StartCoroutine(TypingSubtitleText(CurrentSubtitle));
        }

        if (SubtitleQueue.Count == 0) NoSubtitles = true;
    }

    // checks the length of the subtitle array in SO and queues it
    private void StartTalking(SO_Dialogue DialougeText)
    {
        if (!gameObject.activeSelf) gameObject.SetActive(true);

        SubtitleName.text = DialougeText.SpeakerName;

        for (int i = 0; i < DialougeText.SubtitleTexts.Length; i++)
        {
            SubtitleQueue.Enqueue(DialougeText.SubtitleTexts[i]);
        }
    }

    private void StopTalking()
    {
        NoSubtitles = false;

        if (gameObject.activeSelf) gameObject.SetActive(false);
    }

    // this is what types the subtitle 1 by 1
    private IEnumerator TypingSubtitleText(string CurrentSubtitle)
    {
        Typing = true;

        int maxVisibleChars = 0;

        SubtitleText.text = CurrentSubtitle;
        SubtitleText.maxVisibleCharacters = maxVisibleChars;

        foreach (char c in CurrentSubtitle.ToCharArray())
        {

            maxVisibleChars++;
            SubtitleText.maxVisibleCharacters = maxVisibleChars;

            yield return new WaitForSeconds(MAXTIME / TypingSpeed);
        }

        Typing = false;
    }

    // plays the voice clip of the narrator
    public void PlayNarratorAudio(SO_Dialogue DialougeAudio)
    {
        PlayerSource.PlayOneShot(DialougeAudio.SpeechClip);
    }
}
