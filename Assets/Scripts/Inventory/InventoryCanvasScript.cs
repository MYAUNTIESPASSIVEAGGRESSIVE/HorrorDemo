using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCanvasScript : MonoBehaviour
{
    public PlayerControl PlayerScript;
    public Canvas InventoryCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerScript.Paused = false;
            InventoryCanvas.gameObject.SetActive(false);
        }
    }
}
