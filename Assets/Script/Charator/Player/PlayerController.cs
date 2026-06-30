using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // == Awake Instance == //
    PlayerInput input;
    
    // == Subject == //
    [CanBeNull] public event Action<int> OnHealthChanged;
    
    
    // == Unity API == //
    void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    void Start()
    {
        input.EnableGameplayInput();
    }
    
    
    // == Self Method == //
    public void TakeDamage(int damage)
    {
        OnHealthChanged?.Invoke(damage);
    }
}
