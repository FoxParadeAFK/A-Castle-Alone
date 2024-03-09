using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private int xInput;
    private int yInput;

    public IdleState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputManager.NormInputX;
        yInput = player.InputManager.NormInputY;

        if (xInput != 0) {
            stateMachine.ChangeState(player.MoveState);
        }
    }    
}
