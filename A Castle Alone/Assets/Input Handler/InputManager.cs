using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }

    public void OnMoveInput(InputAction.CallbackContext context) {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);

        Debug.Log($"{NormInputX} + {NormInputY} ");
    }

    public void OnJumpInput(InputAction.CallbackContext context) {

        if (context.started) {
            Debug.Log("Starting");
        }

        if (context.canceled) {
            Debug.Log("Cancelled");
        }
    }
}
