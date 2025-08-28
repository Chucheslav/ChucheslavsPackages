using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture.Base
{
public abstract class GenericSet<T> : ScriptableObject
{
    [SerializeField] private int sizeLimit;
    [SerializeField] private List<T> _items = new();
    public event Action SetChanged;
    public event Action <int, T> ItemReplaced;
    public event Action<int, T> ItemRemoved;
    [SerializeField] private SimpleEvent setChangedEvent;
    [SerializeField] private bool uniqueItemsOnly;

    public IReadOnlyList<T> Items => _items;

    public void RemoveEmptyEntries()
    {
        for (var i = _items.Count -1; i >=0; i--)
        {
            if (_items[i] == null) _items.Remove(_items[i]);
        }
    }

    private void OnValidate()
    {
        if(_items.Count <= sizeLimit) return;
        if(sizeLimit>0) _items.RemoveRange(sizeLimit -1, _items.Count - sizeLimit);
    }

    public bool AddItem(T item)
    {
        if (sizeLimit > 0 && _items.Count >= sizeLimit) return false;
        if (uniqueItemsOnly && _items.Contains(item)) return false;

        if (_items.Contains(item)) return false;
        _items.Add(item);
        SetChanged?.Invoke();
        if(setChangedEvent) setChangedEvent.Raise();
        return true;
    }

    public bool RemoveItem(T t)
    {
        int i = _items.IndexOf(t);
        bool result = _items.Remove(t);

        if (result)
        {
            ItemRemoved?.Invoke(i, t);
            SetChanged?.Invoke();
            if(setChangedEvent) setChangedEvent.Raise();
        }

        return result;
    }

    public bool TryGetItemAt(int index, out T item)
    {
        item = default;
        if (index<0 || index >= _items.Count) return false;
        item = _items[index];
        return true;
    }

    public bool ReplaceItem(int index, T item)
    {
        if (index < 0 || index >= _items.Count) return false;
        if (uniqueItemsOnly && _items.Contains(item)) return false;
        _items[index] = item;
        ItemReplaced?.Invoke(index, item);
        SetChanged?.Invoke();
        if(setChangedEvent) setChangedEvent.Raise();
        return true;
    }

    public void Clear()
    {
        _items.Clear();
        SetChanged = null;
        ItemRemoved = null;
        ItemReplaced = null;
    }

    public bool Any() => _items.Count > 0;

    public int Count => _items.Count;

    public bool Contains(T item) => _items.Contains(item);

    public T this[int index] => _items[index];
}
}