using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private Rigidbody2D rb;

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
        if (obj.control.name == "w")
        {
            rb.velocity = new Vector2(0, jumpSpeed);
        } else
        {
            Debug.Log("Did not press");
        }
    }
}
