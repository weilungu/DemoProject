using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Instance
    Rigidbody2D rb;
    
    [Header("Values")]
    [SerializeField] float speed = 1;
    [SerializeField] int hp = 1;
 
    // Private
    Transform player;
    
    
    // Unity API
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        GetPlayer();
    }
    
    void FixedUpdate()
    {
        Chase();
    }
    
    
    // === Self Method ===
    void GetPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        
        if (playerObj is null) return;
        player = playerObj.transform;
    }
    void Chase()
    {
        if (player is null) return;
        
        Vector2 playerDir = (player.position - transform.position).normalized;
        rb.velocity = playerDir * speed;
    }
    void Dead()
    {
        Destroy(gameObject);
    }
    
    
    // === Self API ===
    public void TakeDamage(int damage)
    {
        hp -= damage;
        print("take damage");

        if (hp <= 0)
        {
            Dead();
            print("Dead");
        }
    }
    
}
