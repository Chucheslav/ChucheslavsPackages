using System;
using UnityEngine;

namespace Tools.TypeSerialization
{
[Serializable]
public class SerializableType: ISerializationCallbackReceiver
{
    [SerializeField] private string assemblyName= string.Empty;
    
    public Type Type {get; private set;} 
    
    public void OnBeforeSerialize()
    {
        assemblyName = Type?.AssemblyQualifiedName ?? assemblyName;
    }

    public void OnAfterDeserialize()
    {
        if (!TryGetType(assemblyName, out Type type))
        {
            Debug.LogError( $"Couldn't find type {type} in assembly: {assemblyName}");
            return;
        }
        Type = type;
    }
    
    public static implicit operator Type(SerializableType s) => s.Type;
    public static implicit operator SerializableType(Type type) => new(){Type = type};

    static bool TryGetType(string typeString, out Type type)
    {
        type = Type.GetType(typeString);
        return type != null || ! string.IsNullOrEmpty(typeString);
    }
}
}
