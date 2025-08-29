using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace YarnExtensions
{
[CreateAssetMenu(menuName = "Yarn Spinner/Extras/Yarn Storage Scriptable Object")]
public class YarnStorageSO: ScriptableObject
{
    [SerializeField] private List<StringEntry> strings;
    [SerializeField] private List<FloatEntry> numbers;
    [SerializeField] private List<BoolEntry> bools;

    [Serializable]
    private class StringEntry
    {
        public string id;
        public string value;
    }
    
    [Serializable]
    private class FloatEntry
    {
        public string id;
        public float value;
    }
    
    [Serializable]
    private class BoolEntry
    {
        public string id;
        public bool value;
    }
    
    public bool TryGetValue<T>(string variableName, out T result)
    {
        result = default(T);

        switch (result)
        {
            case string:
                StringEntry se = strings.FirstOrDefault(s => s.id == variableName);
                if (se == null || se is not T s) return false;
                result = s;
                return true;
            case bool:
                BoolEntry be = bools.FirstOrDefault(s => s.id == variableName);
                if (be == null || be is not T b) return false;
                result = b;
                return true;
            case float:
                FloatEntry fe = numbers.FirstOrDefault(s => s.id == variableName);
                if (fe == null || fe is not T f) return false;
                result = f;
                return true;
            default:
                Debug.LogError($"Unknown variable type {result.GetType()}");
                return false;
        }
    }
    
    public void SetValue(string variableName, string stringValue)
    {
        StringEntry entry = strings.FirstOrDefault(s => s.id == variableName);
        if (entry == null)
        {
            strings.Add(new StringEntry() {id = variableName, value = stringValue});
            return;
        }
        
        entry.value = stringValue;
    }

    public void SetValue(string variableName, float floatValue)
    {
        FloatEntry entry = numbers.FirstOrDefault(s => s.id == variableName);
        if (entry == null)
        {
            numbers.Add(new FloatEntry() { id = variableName, value = floatValue });
            return;
        }
        entry.value = floatValue;
    }

    public void SetValue(string variableName, bool boolValue)
    {
        BoolEntry entry = bools.FirstOrDefault(s => s.id == variableName);
        if (entry == null)
        {
            bools.Add(new BoolEntry() { id = variableName, value = boolValue });
            return;
        }
        entry.value = boolValue;
    }

    public void Clear()
    {
        strings.Clear();
        bools.Clear();
        numbers.Clear();
    }

    public bool Contains(string variableName) => 
        strings.Any(s => s.id == variableName) || bools.Any(s => s.id == variableName) || numbers.Any(s => s.id == variableName);

    public void SetAllVariables(Dictionary<string, float> floats, Dictionary<string, string> strings, Dictionary<string, bool> bools, bool clear = true)
    {
        numbers = floats.Select(s => new FloatEntry() { id = s.Key, value = s.Value }).ToList();
        this.strings = strings.Select(s => new StringEntry() { id = s.Key, value = s.Value }).ToList();
        this.bools = bools.Select(s => new BoolEntry() { id = s.Key, value = s.Value }).ToList();
    }

    public (Dictionary<string, float> FloatVariables, Dictionary<string, string> StringVariables, Dictionary<string, bool> BoolVariables) GetAllVariables() 
        => (numbers.ToDictionary(k => k.id, v => v.value), 
            strings.ToDictionary(k => k.id, v => v.value), 
            bools.ToDictionary(k => k.id, v => v.value) );
}
}