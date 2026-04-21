using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Tools
{
public static class IEnumerableExtensions
{
    public static T RandomElement<T>(this IEnumerable<T> enumerable) => enumerable.ElementAt(Random.Range(0, enumerable.Count()));
    
    public static bool TryFindFirst<T>(this IEnumerable<T> source, Func<T, bool> condition, out T found)
    {
        List<T> enumerationStopper = source.ToList();
        found = enumerationStopper.FirstOrDefault(condition);
        return condition(found) && enumerationStopper.Any();
    }
    
    public static T WeightedRandom<T>(this IEnumerable<T> collection, Func<T, float> weightFunc)
    {
        List<T> enumerationStopper = collection.ToList();
        float total = enumerationStopper.Sum(weightFunc);

        float itemWeightIndex = Random.Range(0, 1f) * total;

        float currentWeight = 0;
        foreach (var item  in enumerationStopper)
        {
            currentWeight += weightFunc(item);

            if (currentWeight > itemWeightIndex) return item;
        }
        
        throw new Exception("Weighted Random failed to return an item, check your weighFunc");
    }
}
}
