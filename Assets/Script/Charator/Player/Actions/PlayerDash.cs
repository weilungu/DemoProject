using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    // Instance
    Rigidbody2D rb;
    TimerMachine timer;
    
    
    [Header("Values")]
    [SerializeField] float dashSpeed = 1f;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldown = 1f;
    
    [Header("Show")]
    [SerializeField] bool canDash = true;
    [SerializeField] bool isDashing = false;
    
    
    // Unity-API
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Dash") && canDash)
        {
            StartCoroutine(DashRoutine());
        }
    }
    

    // Self Method
    IEnumerator DashRoutine()
    {
        Vector2 dashDir = PlayerMovement.Direction;
        if (dashDir == Vector2.zero) yield break;
        
        canDash = false;
        isDashing = true;
        
        // Dashing
        rb.velocity = dashDir * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        
        // Reset State
        rb.velocity = Vector2.zero;
        isDashing = false;
        
        // Cool Down
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    
    
    
    // Self API
    public bool IsDashing => isDashing;
}
