using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tools
{
public static class IEnumerableExtensions
{
    public static T RandomElement<T>(this IEnumerable<T> enumerable) => enumerable.ElementAt(Random.Range(0, enumerable.Count()));

    public static T WeightedRandom<T>(this IEnumerable<T> enumerable, Func<T, float> weightFunc)
    {
        
        var collection = enumerable.ToList();
        
        if (!collection.Any())
        {
            Debug.Log("empty collection passed to weighted random");
            return default;
        }
        float total = collection.Sum(weightFunc);

        float itemWeightIndex = Random.Range(0, 1f) * total;

        float currentWeight = 0;
        foreach (var item  in collection)
        {
            currentWeight += weightFunc(item);

            if (currentWeight > itemWeightIndex) return item;
        }

        return collection.Last();
    }
    
    public static void RemoveWhere<TKey, TValue>(this IDictionary<TKey, TValue> dict, 
        Func<TValue, bool> predicate)
    {
        List<TKey> keys = dict.Keys.Where(k => predicate(dict[k])).ToList();
        foreach (var key in keys)
        {
            dict.Remove(key);
        }
    }

    public static IEnumerable<T> RemoveWhere<T>(this IEnumerable<T> iEnumerable, Func<T, bool> predicate) => iEnumerable.Except(iEnumerable.Where(e => predicate(e)));

    public static bool TryFindFirst<T>(this IEnumerable<T> source, Func<T, bool> condition, out T found)
    {
        T[] enumerable = source as T[] ?? source.ToArray();
        found = enumerable.FirstOrDefault(condition);
        return enumerable.Any(condition);
    }

    public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source) => new HashSet<T>(source);

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        List<T> enumerable = source.ToList();
        return enumerable.OrderBy(t => t.GetHashCode() + Random.Range(0, enumerable.Count() * 2));
    }
}
}
