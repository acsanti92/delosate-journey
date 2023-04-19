using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    // This is the hash of the FreeLookSpeed parameter in the Animator
    private readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");

    // This is the damp time for the Animator
    private const float AnimatorDampTime = 0.1f;

    // Constructor for the PlayerTestState class
    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {

    }

    public override void Tick(float deltaTime)
    {
        // Create a new Vector3
        Vector3 movement = CalculateMovement();

        // Move the CharacterController by the movement Vector3 multiplied by the deltaTime and the FreeLookMovementSpeed
        stateMachine.Controller.Move(movement * deltaTime * stateMachine.FreeLookMovementSpeed);

        // If the InputReader's MovementValue is equal to Vector2.zero, return
        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0, AnimatorDampTime, deltaTime);
            return;
        }
        // When we are moving set the FreeLookSpeed to 1
        stateMachine.Animator.SetFloat(FreeLookSpeedHash, 1, AnimatorDampTime, deltaTime);
        // Set the rotation of the CharacterController to the rotation of the Quaternion.LookRotation of the movement Vector3
        FaceMovementDirection(movement, deltaTime);
    }

    public override void Exit()
    {

    }

    private Vector3 CalculateMovement()
    {
        // Get the forward and right vectors of the MainCameraTransform
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        // Set the y values of the forward and right vectors to 0
        forward.y = 0f;
        right.y = 0f;

        // Normalize the forward and right vectors
        forward.Normalize();
        right.Normalize();

        return forward * stateMachine.InputReader.MovementValue.y + right * stateMachine.InputReader.MovementValue.x;
    }

    private void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation,
            Quaternion.LookRotation(movement),
            stateMachine.RotationDamping * deltaTime
        );
    }
}
