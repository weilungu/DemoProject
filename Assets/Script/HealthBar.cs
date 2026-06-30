using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Health health;
    
    // Private
    Slider slider;
    
    
    // == Unity API == //
    void OnEnable()
    {
        health.OnHealthChanged += SetHealth;
        health.OnMaxHealthChanged += SetMaxHealth;
    }
    void OnDisable()
    {
        health.OnHealthChanged -= SetHealth;
        health.OnMaxHealthChanged -= SetMaxHealth;
    }

    void Awake()
    {
        slider = GetComponent<Slider>();
    }


    // == Self Method == //
    public void SetHealth(int health)
    {
        slider.value = health;
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        // slider.value = health;
        SetHealth(health);
    }
}
