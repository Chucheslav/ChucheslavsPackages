using UnityEngine;
using UnityEventsAndComponents.Counters;
using Yarn.Unity;

namespace YarnExtensions
{
public static class YarnCounterFunctions
{
    [YarnFunction("float_counter")]
    public static float GetFloatCounterValue(string objectName)
    {
        GameObject floatCounter = GameObject.Find(objectName);
        
        if (!floatCounter)
        {
            Debug.LogError($"Can't find GameObject {floatCounter.name} ");
            return 0f;
        }
    
        if (!floatCounter.TryGetComponent<FloatCounter>(out var counter))
        {
            Debug.LogError($"Can't find FloatCounter component on GameObject {floatCounter.name} ");
            return 0f;
        }
        
        return counter.Value;
    }

     [YarnFunction("int_counter")]
     public static int GetIntCounterValue(string objectName)
     {
         GameObject intCounter = GameObject.Find(objectName);
         
         if (!intCounter)
         {
             Debug.LogError($"Can't find GameObject {intCounter.name} ");
             return 0;
         }
    
         if (!intCounter.TryGetComponent<IntCounter>(out var counter))
         {
             Debug.LogError($"Can't find IntCounter component on GameObject {intCounter.name} ");
             return 0;
         }
         
         return counter.Value;
    }
}
}