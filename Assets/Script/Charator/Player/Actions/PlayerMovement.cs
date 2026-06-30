using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Instance
    Rigidbody2D rb;
    SpriteRenderer sprite;
    
    [Header("Inspector Values")]
    [SerializeField] float speed = 1;
    
    [Header("Show")]
    [SerializeField] Vector2 dir;
    
    // Unity API
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        dir = Direction;
    }

    // Self API
    public void Move()
    {
        if (Direction.x != 0) // 翻轉玩家 Sprite
            sprite.flipX = dir.x < 0;
        
        rb.velocity = Direction * speed;
    }
    public void StopMove() => rb.velocity = Vector2.zero;

    public float GetSpeed() => speed;
    
    public static Vector2 Direction => // get move direction
        new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;


}
