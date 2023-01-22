using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private Rigidbody2D rb;
    private bool isJump = false;
    private bool isOneJump = false;
    private bool isTwoJump = false;

    public int jumpSpeed = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Enable();
        inputActions.PlayerControls.Moviment.performed += onPlayerInput;
    }

    private void onPlayerInput(InputAction.CallbackContext obj)
    {
        if (obj.control.name == "space")
        {
            if (!isJump && !isOneJump)
            {
                rb.velocity = new Vector2(0, jumpSpeed);
                isOneJump = true;
                isJump = true;
                Debug.Log("first if");
                FindObjectOfType<MusicManager>().JumpingSound();

            }
            else if (isJump && isOneJump && !isTwoJump)
            {
                isTwoJump = true;
                rb.velocity = new Vector2(0, jumpSpeed);
                Debug.Log("second if");
                FindObjectOfType<MusicManager>().JumpingSound();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Ground"))
        {
            isJump = false;
            isOneJump = false;
            isTwoJump = false;
            Debug.Log("Is trigger");
        }
    }
}
