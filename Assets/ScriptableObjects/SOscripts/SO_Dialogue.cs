using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialouge", menuName = "Dialouge/New Dialouge")]
public class SO_Dialogue : ScriptableObject
{
    public string SpeakerName;

    [TextArea(5, 10)]
    public string SubtitleTexts;

    public AudioClip SpeechClip;
}
