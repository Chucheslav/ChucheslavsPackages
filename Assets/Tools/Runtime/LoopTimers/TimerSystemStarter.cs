using UnityEditor;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace Tools.LoopTimers
{
internal static class TimerSystemStarter
{
    static PlayerLoopSystem _timerSystem;
    
    static bool InsertTimerManager<T>(ref PlayerLoopSystem loop, int index)
    {
        _timerSystem = new PlayerLoopSystem()
            {type = typeof(TimerManager), updateDelegate = TimerManager.UpdateTimers, subSystemList = null};
        return PlayerLoopTools.InsertSystem<T>(ref loop, in _timerSystem, index);
    }

    static void RemoveTimerManager<T>(ref PlayerLoopSystem loop) => 
        PlayerLoopTools.RemoveSystem<T>(ref loop, in _timerSystem);

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    static void Initialize()
    {
        PlayerLoopSystem loop = PlayerLoop.GetCurrentPlayerLoop();
        if (!InsertTimerManager<Update>(ref loop, 0))
        {
            Debug.LogError("Unable to insert TimerManager into PlayerLoop");
            return;
        }
        
        //PlayerLoopTools.PrintToConsole(loop);
        
#if UNITY_EDITOR

        EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;

        static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.ExitingPlayMode) return;
            PlayerLoopSystem currentLoop = PlayerLoop.GetCurrentPlayerLoop();
            RemoveTimerManager<Update>(ref currentLoop);
            TimerManager.Clear();
        }
#endif
    }
}
}
