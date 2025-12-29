using System;
using System.Linq;

namespace Tools.Extensions
{
public static class ReflectionExtensions
{
    public static bool TryGetGenericType(this Type ofType, out Type genericType)
    {
        if (ofType is not {IsGenericType: true})
        {
            genericType = null;
            return false;
        }

        genericType = ofType.GetGenericTypeDefinition();
        return true;
    }

    public static bool InheritsOrImplements(this Type type, Type baseType)
    {
        type = ResolveGenericType(type);
        baseType = ResolveGenericType(baseType);

        while (type != typeof(object))
        {
            if (baseType == type || HasAnyInterfaceOfType(type, baseType)) return true;

            type = ResolveGenericType(type.BaseType);
            if (type == null) return false;
        }

        return false;
    }

    static Type ResolveGenericType(Type type)
    {
        if (type is not {IsGenericType: true}) return type;

        var genericType = type.GetGenericTypeDefinition();
        return genericType != type ? genericType : type;
    }

    static bool HasAnyInterfaceOfType(Type type, Type interfaceType)
    {
        return type.GetInterfaces().Any(i => ResolveGenericType(i) == interfaceType);
    }
}
}