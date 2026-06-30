using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject healthBar;

    
    // == Unity API == //
    void OnEnable()
    {
        player.OnHealthChanged += ReduceHealth;
    }

    void OnDisable()
    {
        player.OnHealthChanged -= ReduceHealth;
    }
    
    
    // == Self Method == // 
    void ReduceHealth(int amount)
    {
        print($"Reduce Health: {amount}");
        print("healthBar reduce amount");
    }
}
