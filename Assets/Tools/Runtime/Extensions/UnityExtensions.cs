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
    
    public static bool TryGetComponentInTree<T>(this GameObject target, out T component) where T : Component => TryGetComponentInTree<T>(target.transform, out component);

    public static bool TryGetComponentInTree<T>(this Transform target, out T component, bool startWithTarget = true) where T : Component
    {
        component = null;
        if (!target) return false;
        
        if (startWithTarget && target.TryGetComponent(out component)) return true;
        
        T[] allComponents = target.root.GetComponentsInChildren<T>();
        if (allComponents.Length == 0) return false;
        if(allComponents.Length >1) target.gameObject.LogWarning($"more then one component of type {typeof(T).Name} found in hierarchy, returning first one found");
        component = allComponents[0];
        return true;
    }

    public static void LogMessage(this Object MB, string message) => 
        Debug.Log($"Script {MB.GetType().Name} on object {MB.name} says:" + message);
    
    public static void LogWarning(this Object MB, string message) => 
        Debug.LogWarning($"Script {MB.GetType().Name} on object {MB.name} warns:" + message);
    
    public static void LogError(this Object MB, string message) => 
        Debug.LogError($"Script {MB.GetType().Name} on object {MB.name} logged error:" + message);

    public static bool IsInLayerMask(this GameObject gameObject, LayerMask layerMask) =>
        (layerMask & (1 << gameObject.layer)) != 0;

}
}