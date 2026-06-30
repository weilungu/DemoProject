using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    // == Awake Instance == //
    PlayerInput input;
    Health health;
    
    // == Inspector Values == //
    
    
    // == Unity API == //
    void Awake()
    {
        input = GetComponent<PlayerInput>();
        health = GetComponent<Health>();
    }

    void Start()
    {
        input.EnableGameplayInput();
    }

    void Update()
    {
        int randomAmount = Random.Range(0, 20);

        if (Input.GetMouseButtonDown(0))
            health.Heal(randomAmount);
        else if (Input.GetMouseButtonDown(1))
            health.TakeDamage(randomAmount);
    }
}
