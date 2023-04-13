using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    // This is the current state of the state machine
    private State currentState;

    public void SwitchState(State newState)
    {
        // If there is a current state, exit it
        currentState?.Exit();

        // Set the current state to the new state
        currentState = newState;

        // Enter the new state
        currentState?.Enter();
    }

    private void Update()
    {
        currentState?.Tick(Time.deltaTime);
    }
}
