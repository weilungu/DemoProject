using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateContext
{
    public Rigidbody2D rb;
    public PlayerInput input;
    public Animator anim;
    public PlayerMovement movement;
    
    public PlayerStateContext(
        Rigidbody2D rb,
        PlayerInput input,
        Animator anim,
        PlayerMovement movement)
    {
        this.rb = rb;
        this.input = input;
        this.anim = anim;
        this.movement = movement;
    }
}
