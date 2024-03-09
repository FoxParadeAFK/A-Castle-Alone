using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected Player player;
    protected StateMachine stateMachine;
    protected PlayerData playerData;
    protected string animBoolName;

    protected bool isAnimationFinished;
    protected float startTime;

    public State(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName) {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter() {
        DoCheck();

        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;

        isAnimationFinished = false;

        Debug.Log(animBoolName);
    }

    public virtual void Exit() {
        player.Anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate() {
        DoCheck();
    }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() { 
        isAnimationFinished = true;
    }

    protected virtual void DoCheck() { }
}
