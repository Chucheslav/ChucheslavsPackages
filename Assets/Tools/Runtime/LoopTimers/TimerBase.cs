using System;
using Tools.LoopTimers;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public abstract class TimerBase: IDisposable
{
   [field:SerializeField] public float InitialTime { get; protected set; }
   [field:SerializeField] public float CurrentTime { get; protected set; }
   [field:SerializeField] public bool IsRunning { get; protected set; }
   [field:SerializeField] public bool IsFinished { get; protected set; }
   
   public abstract float Progress { get; }

   public event Action TimerStarted = delegate { };
   public event Action TimerStopped = delegate { };
   public event Action TimerFinished = delegate { };
   
   public UnityEvent timerStartedEvent;
   public UnityEvent timerStoppedEvent;
   public UnityEvent timerFinishedEvent;
   
   private bool _disposed;

   protected TimerBase(float initialTime)
   {
       InitialTime = initialTime;
   }

   public void Start()
   {
       CurrentTime = InitialTime;
       if(IsRunning) return;
       IsRunning = true;
       TimerManager.Register(this);
       TimerStarted.Invoke();
       timerStartedEvent.Invoke();
   }
   
   public virtual void Reset()
   {
       IsFinished = false;
       CurrentTime = InitialTime;
   }

   public virtual void SetNewTime(float initialTime) => InitialTime = initialTime;

   protected virtual void Finish()
   {
       IsFinished = true;
       Stop();
       TimerFinished.Invoke();
       timerFinishedEvent.Invoke();
   }

   public void Stop()
   {
       if(!IsRunning) return;
       IsRunning = false;
       TimerManager.Unregister(this);
       TimerStopped.Invoke();
       timerStoppedEvent.Invoke();
   }
   
   public abstract void Tick();

   #region IDisposable Support
    ~TimerBase() => Dispose(false);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        {
            if (disposing) 
                TimerManager.Unregister(this);

            _disposed = true;
        }
    }
    #endregion
}
