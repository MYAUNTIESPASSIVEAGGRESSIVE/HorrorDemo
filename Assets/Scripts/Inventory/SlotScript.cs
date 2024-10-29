using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    [Header("References")]
    public Image Icon;
    public TMP_Text Description;

    public void EmptySlot()
    {
        Icon.enabled = false;
        Description.enabled = false;
    }

    public void CreateSlot()
    {

    }
}
