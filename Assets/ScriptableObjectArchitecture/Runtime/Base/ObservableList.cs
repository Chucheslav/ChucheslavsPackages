using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScriptableObjectArchitecture.Base
{
public abstract class ObservableList<T> : ScriptableObject
{
    [SerializeField] private List<T> list = new();
    [SerializeField] private bool duplicatesAllowed = true;

    /// <summary>
    /// true for added
    /// </summary>
    public event Action<T, bool> ListChanged;

    public event Action ListCleared;
    
    public IReadOnlyList<T> GetAll() => list.AsReadOnly();

    public bool Remove(T item)
    {
        if (!list.Remove(item)) return false;
        ListChanged?.Invoke(item, false);
        return true;
    }

    public bool Add(T item)
    {
        if (!duplicatesAllowed && list.Contains(item)) return false;
        list.Add(item);
        ListChanged?.Invoke(item, true);
        return true;
    }

    public bool Contains(T item) => list.Contains(item);
    public bool Any(Func<T, bool> condition) => list.Any(condition);

    public bool TryFindFirst(Func<T, bool> condition, out T found)
    {
        found = list.FirstOrDefault(condition);
        return list.Any(condition);
    }

    public void Clear()
    {
        list.Clear();
        ListCleared?.Invoke();
    }
}
}