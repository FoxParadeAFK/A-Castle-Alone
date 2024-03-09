using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private int xInput;
    private int yInput;

    public MoveState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputManager.NormInputX;
        yInput = player.InputManager.NormInputY;

        player.CheckIfShouldFlip(xInput);

        player.SetVelocityX(10 * xInput);

        if (xInput == 0) {
            stateMachine.ChangeState(player.IdleState);
        }
    }
}
