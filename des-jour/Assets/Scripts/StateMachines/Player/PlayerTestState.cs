using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    // Timer for the state
    private float timer;
    // Constructor for the PlayerTestState class
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        // If the jump button is pressed
        stateMachine.InputReader.JumpEvent += OnJump;
    }

    public override void Tick(float deltaTime)
    {
        // Decrement the timer
        timer += deltaTime;

        Debug.Log(timer);
    }

    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent -= OnJump;
    }

    //
    private void OnJump()
    {
        // Switch to the next state
        stateMachine.SwitchState(new PlayerTestState(stateMachine));
    }
}
