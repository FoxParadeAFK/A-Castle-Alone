using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    public StateMachine StateMachine { get; private set; }
    public Animator Anim { get; private set; }

    public InputManager InputManager { get; private set; }
    public Rigidbody2D RB { get; private set; }

    public IdleState IdleState { get; private set; }
    public JumpState JumpState { get; private set; }
    public MeleeAttackState MeleeAttackState { get; private set; }
    public MoveState MoveState { get; private set; }
    public RangedAttackState RangedAttackState { get; private set; }

    [SerializeField] private Transform wallCheck;
    private Vector2 workspace;

    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    private void Awake() {
        StateMachine = new StateMachine();

        IdleState = new IdleState(this, StateMachine, playerData, "idle");
        JumpState = new JumpState(this, StateMachine, playerData, "jump");
        MeleeAttackState = new MeleeAttackState(this, StateMachine, playerData, "melee");
        MoveState = new MoveState(this, StateMachine, playerData, "move");
        RangedAttackState = new RangedAttackState(this, StateMachine, playerData, "range");
    }

    private void Start() {
        Anim = GetComponent<Animator>();
        InputManager = GetComponent<InputManager>();
        RB = GetComponent<Rigidbody2D>();
        FacingDirection = 1;

        StateMachine.Initialize(IdleState);
    }

    private void Update() {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate() {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityX(float velocity) {
        workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }
    public void SetVelocityZero() {
        RB.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }

    public void CheckIfShouldFlip(int xInput) {
        if (xInput != 0 && xInput != FacingDirection) {
            Flip();
        }
    }
    private void Flip() {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    
    
}
