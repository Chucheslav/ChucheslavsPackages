using System;
using UnityEngine;

namespace Tools.LoopTimers
{
[Serializable]
public class CountDownTimer: TimerBase
{
    public override float Progress => Mathf.Clamp01(1 - CurrentTime / InitialTime);
    
    public CountDownTimer(float initialTime) : base(initialTime) { }
    
    public override void Tick()
    {
        if(!IsRunning) return;
       
        if(CurrentTime>0) CurrentTime -= Time.deltaTime;

        else Finish();
    }
}
}
