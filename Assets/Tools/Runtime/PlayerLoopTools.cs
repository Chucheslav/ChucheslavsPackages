using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.LowLevel;

namespace Tools
{
public static class PlayerLoopTools
{
    public static bool InsertSystem<T>(ref PlayerLoopSystem loop, in PlayerLoopSystem toInsert, int index)
    {
        if (loop.type == typeof(T))
        {
            List<PlayerLoopSystem> systemList = new List<PlayerLoopSystem>();
            if(loop.subSystemList != null) systemList.AddRange(loop.subSystemList);
            systemList.Insert(index, toInsert);
            loop.subSystemList = systemList.ToArray();
            return true;
        }
        
        if(loop.subSystemList == null) return false;
        for (int i = 0; i < loop.subSystemList.Length; i++)
        {
            if (!InsertSystem<T>(ref loop.subSystemList[i], in toInsert, index)) continue;
            //Debug.Log($"Inserting loop system {toInsert.type}");
            return true;
        }

        return false;
    }

    public static void RemoveSystem<T>( ref PlayerLoopSystem loop, in PlayerLoopSystem toRemove)
    {
        if (loop.subSystemList == null) return;
        List<PlayerLoopSystem> systemList = loop.subSystemList.ToList();
        for (int i = 0; i < systemList.Count; i++)
        {
            PlayerLoopSystem system = systemList[i];
            if (system.type != toRemove.type || system.updateDelegate != toRemove.updateDelegate) continue;
            systemList.RemoveAt(i);
            loop.subSystemList = systemList.ToArray();
            //Debug.Log($"Removing loop system {toRemove.type}");
            return;
        }
        
        foreach (PlayerLoopSystem subSystem in loop.subSystemList) 
            RemoveSystem<T>(ref loop, in subSystem);
    }
    
    public static void PrintToConsole(PlayerLoopSystem loop, int indent = 2)
    {
        StringBuilder output = new StringBuilder();
        output.AppendLine("PlayerLoopSubSystems:");
        foreach (PlayerLoopSystem system in loop.subSystemList)
        {
            AddSystemRecursively(system, 0);
        }
        Debug.Log( output.ToString() );
        void AddSystemRecursively(PlayerLoopSystem system, int level)
        {
            output.Append(' ', level*indent).AppendLine(system.type.ToString());
            if (system.subSystemList == null ||  system.subSystemList.Length == 0) return;
            foreach (PlayerLoopSystem subSystem in system.subSystemList) 
                AddSystemRecursively(subSystem, level + 1);
        }
    }
}
}
