using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    // Timer for the state
    private float timer = 5f;
    // Constructor for the PlayerTestState class
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Enter");
    }

    public override void Tick(float deltaTime)
    {
        // Decrement the timer
        timer -= deltaTime;
        Debug.Log(timer);

        // If the timer is less than or equal to 0
        if (timer <= 0)
        {
            // Switch to the next state
            stateMachine.SwitchState(new PlayerTestState(stateMachine));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit");
    }
}
