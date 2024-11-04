using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("References")]
    public CharacterController PlayerController;
    public InventoryCanvasScript InventoryScript;
    public Transform PlTransform;
    public Transform CamHolder;
    public Canvas InventoryCanvas;

    [Header("Player Variables")]
    public float MoveSpeed = 5f;
    public float LookRotSpeed = 5f;
    public float LookVertSpeed = 5f;
    public bool LookingAtItem = false;
    public bool Paused = false;
    private float HozPos;
    private float VertPos;
    private float CamRotX = 0f;

    private void Start()
    {
        PlayerController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HozPos = Input.GetAxisRaw("Horizontal");
        VertPos = Input.GetAxisRaw("Vertical");

        // if they are paused they cannot move or look around
        if (!Paused)
        {
            // if the player is looking at an item then they will not be able to move.
            if (!LookingAtItem) CharacterMovement();

            CameraRotation();

            // if the player presses I then the player will view in the inventory
            if (Input.GetKeyDown(KeyCode.I))
            {
                InventoryCanvas.gameObject.SetActive(true);
                Paused = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * LookRotSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * LookVertSpeed;

        CamRotX -= mouseY;
        CamRotX = Mathf.Clamp(CamRotX, -90f, 90f);

        CamHolder.localRotation = Quaternion.Euler(CamRotX, 0f, 0f);

        PlTransform.Rotate(Vector3.up, mouseX);
    }

    private void CharacterMovement()
    {
        Vector3 playerMove = transform.right * HozPos + transform.forward * VertPos;

        PlayerController.Move(playerMove * MoveSpeed * Time.deltaTime);
    }
}
