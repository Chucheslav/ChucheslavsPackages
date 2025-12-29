using System;
using UnityEngine;

namespace Tools.LoopTimers
{
[Serializable]
public class StopwatchTimer: TimerBase
{
    public StopwatchTimer() : base(0){}
    

    public override float Progress => IsRunning ? -1f : 0; //no point in this value
    public override void Tick()
    {
       if (!IsRunning) return;
       CurrentTime += Time.deltaTime;
    }
}
}