using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitleScript : MonoBehaviour, ISubtitleCreate
{
    public SO_Dialogue DialogueSO;
    
    public SubtitleManager PlayerSubtitles;

    public void StartDialouge()
    {
        Debug.Log("Do Stuff");
        Subtitles(DialogueSO);
    }

    public void Subtitles(SO_Dialogue DialogueSO)
    {
        PlayerSubtitles.DisplaySubtitle(DialogueSO);
        PlayerSubtitles.PlayNarratorAudio(DialogueSO);

    }
}
