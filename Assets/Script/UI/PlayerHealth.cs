using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject healthBar;

    
    // // == Unity API == //
    // void OnEnable()
    // {
    //     player.OnHealthChanged += UpdateHealthUI;
    // }
    //
    // void OnDisable()
    // {
    //     player.OnHealthChanged -= UpdateHealthUI;
    // }
    
    // == Self Method == // 
    void UpdateHealthUI(int health)
    {
        
    }
}
