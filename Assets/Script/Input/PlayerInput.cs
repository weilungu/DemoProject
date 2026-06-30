using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions inputActions;
    Vector2 axis => inputActions.GamePlay.Axis.ReadValue<Vector2>();
    
    
    // == Get Button Down ==
    public bool Move => Horizontal != 0 || Vertical != 0;
    public bool Attack => inputActions.GamePlay.Attack.WasPressedThisFrame();
    
    
    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    
    public void EnableGameplayInput()
    {
        inputActions.GamePlay.Enable();
    }
    
    // == API ==
    public Vector2 Axis => axis;
    public float Horizontal => Axis.x;
    public float Vertical => Axis.y;
    
}
