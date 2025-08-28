using System;
using UnityEngine;

namespace Tools
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
    
