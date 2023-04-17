using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{

    // Constructor for the PlayerTestState class
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {

    }

    public override void Tick(float deltaTime)
    {
        // Create a new Vector3
        Vector3 movement = new Vector3();
        // Set the x, y, and z values of the Vector3 to the x, y, and z values of the InputReader's MovementValue
        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0;
        movement.z = stateMachine.InputReader.MovementValue.y;
        // Translate the player by the movement Vector3
        stateMachine.transform.Translate(movement * deltaTime);
    }

    public override void Exit()
    {

    }
}
