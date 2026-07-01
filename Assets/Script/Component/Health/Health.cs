using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    
    [Header("Show")]
    [SerializeField] int currHealth;
    
    public event Action<int> OnHealthChanged;
    public event Action<int> OnMaxHealthChanged;

    
    // == Unity API == //
    private void Start()
    {
        currHealth = maxHealth;
        
        OnMaxHealthChanged?.Invoke(maxHealth);
        OnHealthChanged?.Invoke(currHealth);
    }


    public void TakeDamage(int amount)
    {
        currHealth -= amount;
        
        OnHealthChanged?.Invoke(currHealth);
        print($"Take Damage: {amount}");
    }

    public void Heal(int amount)
    {
        currHealth += amount;
        
        OnHealthChanged?.Invoke(currHealth);
    }
}
