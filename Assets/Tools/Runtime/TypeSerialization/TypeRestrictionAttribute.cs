using System;
using UnityEngine;

namespace Tools.TypeSerialization
{
public class TypeRestrictionAttribute : PropertyAttribute
{
    public Type Type { get; }

    public TypeRestrictionAttribute(Type type)
    {
        Type = type;
    }
}
}
    
