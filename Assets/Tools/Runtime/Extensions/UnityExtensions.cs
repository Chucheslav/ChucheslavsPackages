using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Tools.Extensions
{
public static class UnityExtensions
{
    //Breadth-first search
    public static Transform DeepFind(this Transform parent, string name)
    {
        Queue<Transform> children = new Queue<Transform>();
        children.Enqueue(parent);

        while (children.Count > 0)
        {
            Transform c = children.Dequeue();
            if (c.name == name) return c;
            foreach (Transform child in c) children.Enqueue(child);
        }
        return null;
    }
    public static RectTransform DeepFind(this RectTransform parent, string name)
    {
        Queue<RectTransform> children = new Queue<RectTransform>();
        children.Enqueue(parent);

        while (children.Count > 0)
        {
            RectTransform c = children.Dequeue();
            if (c.name == name) return c;
            foreach (RectTransform child in c) children.Enqueue(child);
        }
        return null;
    }

    public static void LogMessage(this Object MB, string message) => 
        Debug.Log($"Script {MB.GetType().Name} on object {MB.name} says:" + message);
    
    public static void LogWarning(this Object MB, string message) => 
        Debug.LogWarning($"Script {MB.GetType().Name} on object {MB.name} warns:" + message);
    
    public static void LogError(this Object MB, string message) => 
        Debug.LogError($"Script {MB.GetType().Name} on object {MB.name} logged error:" + message);

}
}