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
        // Move the CharacterController by the movement Vector3 multiplied by the deltaTime and the FreeLookMovementSpeed
        stateMachine.Controller.Move(movement * deltaTime * stateMachine.FreeLookMovementSpeed);

        // If the InputReader's MovementValue is equal to Vector2.zero, return
        if (stateMachine.InputReader.MovementValue == Vector2.zero) { return; }
        // Set the rotation of the CharacterController to the rotation of the Quaternion.LookRotation of the movement Vector3
        stateMachine.transform.rotation = Quaternion.LookRotation(movement);
    }

    public override void Exit()
    {

    }
}
