using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    // This is the value of the movement input
    public Vector2 MovementValue { get; private set; }

    // This is an event that is called when the jump button is pressed
    public event Action JumpEvent;
    // This is an event that is called when the dodge button is pressed
    public event Action DodgeEvent;

    private Controls controls;

    private void Start()
    {
        controls = new Controls();
        // This ensures that the input reader is listening for input
        controls.Player.SetCallbacks(this);
        // This enables the input reader to listen for input
        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        // This disables the input reader from listening for input
        controls.Player.Disable();
    }

    // This is called when the jump button is pressed
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        JumpEvent?.Invoke();
    }

    // This is called when the dodge button is pressed
    public void OnDodge(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        DodgeEvent?.Invoke();
    }

    // Sets the movement value to the value of the input
    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }
}
