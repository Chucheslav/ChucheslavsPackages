using System;
using UnityEngine;

namespace Tools.LoopTimers
{
[Serializable]
public class CountupTimer: TimerBase
{
    [SerializeField] private float targetTime;

    public CountupTimer(float targetTime, float initialTime = 0) : base(initialTime)
    {
        this.targetTime = targetTime;
    }
    public override float Progress => Mathf.Clamp01(CurrentTime/targetTime);
    public override void Tick()
    {
        if(!IsRunning) return;
        if(CurrentTime < targetTime) CurrentTime += Time.deltaTime;
        else Finish();
    }
}
}