using System.Collections.Generic;
using System.Linq;
using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
public class ScriptableEnumPref<T> : ScriptablePref<T> where T: ScriptableEnum
{
    [SerializeField] private T[] enumValues;

    public  IReadOnlyCollection<T> EnumValues => enumValues;

    protected override void Save()
    {
        PlayerPrefs.SetString(prefID, Value.DisplayName);
    }

    protected override T LoadValue()
    { 
        if (!enumValues.Any())
        {
            Debug.LogError("Scriptable pref " + PrefID + "has empty values" );
            return null;
        }

        string savedName = PlayerPrefs.GetString(prefID);
        T foundValue = enumValues.FirstOrDefault(t => t && t.DisplayName == savedName);

        if (foundValue) return foundValue;
        
        Debug.Log($@"No value with ID {savedName} found for scriptable enum pref {prefID}, loading first value");
        return enumValues.First();
    }

    public T this[string name] => enumValues.First(t => t.DisplayName == name);
}
}
