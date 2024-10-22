using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("References")]
    public CharacterController PlayerController;
    public GameObject CameraHolder;

    [Header("Player Variables")]
    public float MoveSpeed = 5f;
    public float LookSpeed = 5f;
    public float LookLimit = 90f;
    private float HozPos;
    private float VertPos;
    private float mouseX;
    private float mouseY;

    private void Start()
    {
        PlayerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HozPos = Input.GetAxisRaw("Horizontal");
        VertPos = Input.GetAxisRaw("Vertical");

        mouseX = Input.GetAxisRaw("MouseX");
        mouseY = Input.GetAxisRaw("MouseY");

        CharacterMovement();

        CameraRotation();
    }

    private void CameraRotation()
    {
        
    }

    private void CharacterMovement()
    {
        Vector3 playerMove = new Vector3(HozPos, 0, VertPos);

        PlayerController.Move(playerMove * MoveSpeed * Time.deltaTime);
    }
}
