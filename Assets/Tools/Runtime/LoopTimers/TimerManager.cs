using System.Collections.Generic;

namespace Tools.LoopTimers
{
public static class TimerManager
{
    private static readonly List<TimerBase> timers = new();
    private static readonly List<TimerBase> copy = new();
    
    public static void Register(TimerBase timer) => timers.Add(timer);
    public static void Unregister(TimerBase timer) => timers.Remove(timer);

    public static void UpdateTimers()
    {
        if(timers.Count == 0) return;
        copy.AddRange(timers);
        foreach (TimerBase timer in copy)
        {
            timer.Tick();
        }
        copy.Clear();
    }

    public static void Clear()
    {
        if (timers.Count > 0)
        {
            copy.Clear();
            copy.AddRange(timers);
            foreach (TimerBase timer in copy) 
                timer.Dispose();
        }
        
        copy.Clear();
        timers.Clear();
    }
}
}