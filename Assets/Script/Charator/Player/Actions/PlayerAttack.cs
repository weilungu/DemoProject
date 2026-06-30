using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Values")]
    [SerializeField] int attackDamage;
    [SerializeField] float attackRange;
    [SerializeField] float attackCooldown;
    [SerializeField] int attackCount = 1;
    
    [Header("Inspector References")]
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask enemyLayer;

    [Header("ScriptableObjects")] 
    [SerializeField] PlayerState_Attack attackState;
    
    // Private
    Collider2D[] enemies;
   
    void Awake()
    {
        enemies = new Collider2D[attackCount];
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
    }

    void OnDrawGizmosSelected()
    {
        // Show Attack Range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    // Self Methods
    void Attack()
    {
        // Get Enemies Colliders and Counts
        int enemiesCount = Physics2D.OverlapCircleNonAlloc(
            attackPoint.position,
            attackRange,
            enemies,
            enemyLayer);

        
        // If Collider touch Enemy, then attack that
        if (enemiesCount <= 0) return;
        foreach (Collider2D em in enemies)
        {
            em.GetComponent<Enemy>().TakeDamage(attackDamage);
            print("Tk_Dm");
        }
    }
}
