using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScriptableObjectArchitecture.Base
{
public abstract class RuntimeSet<T> : ScriptableObject
{
    private List<T> _items = new();
    public IReadOnlyList<T> Items => _items;

    public event Action SetChanged;
    [SerializeField] private SimpleEvent setChangedEvent;
    
    private void Awake()
    {
        Clear();
    }

    private void OnDisable() => Clear();

    public void RemoveEmptyEntries()
    {
        for (var i = _items.Count -1; i >=0; i--)
        {
            if (_items[i] == null) _items.Remove(_items[i]);
        }
    }

    public bool AddItem(T t)
    {
        if (_items.Contains(t)) return false;
        _items.Add(t);
        SetChanged?.Invoke();
        if(setChangedEvent) setChangedEvent.Raise();
        return true;
    }

    public bool RemoveItem(T t)
    {
        bool result = _items.Remove(t);

        if (result)
        {
            SetChanged?.Invoke();
            if(setChangedEvent) setChangedEvent.Raise();
        }

        return result;
    }

    public void AddRange(IEnumerable<T> collection)
    {
        _items.AddRange(collection.Where(t => !_items.Contains(t)));
        SetChanged?.Invoke();
    }
    
    public void Clear()
    {
        _items.Clear();
        SetChanged = null;
    }

    public bool Any() => _items.Count > 0;

    public int Count => _items.Count;

    public bool Contains(T item) => _items.Contains(item);
    
    public T this[int index] => _items[index];
}
}