using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMachine
{
    float timer = 0;
    bool isRunning = false;

    // Self-Method
    public void TimingStart()
    {
        timer = 0;
        isRunning = true;
    }
    public bool Tick(float interval)
    {
        timer += Time.deltaTime;
        
        if (timer < interval) return false;
        
        timer -= interval;
        return true;
    }

    // public void Timer(float duration)
    // {
    //     if (!isRunning) return;
    //     
    //     
    //     timer += Time.deltaTime;
    //     if (timer >= duration)
    //     {
    //         Debug.Log("Timer out");
    //         isRunning = false;
    //         
    //         timer = 0;
    //     }
    // }
    
    
    // Self-API
    public void Reset() => timer = 0;
    public bool IsFinished => !isRunning;
}
