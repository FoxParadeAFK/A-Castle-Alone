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


    
    
}
