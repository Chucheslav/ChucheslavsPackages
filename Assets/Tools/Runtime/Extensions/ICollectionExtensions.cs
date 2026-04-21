using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Tools
{
    public static class ICollectionExtensions
    {
        public static IEnumerable<T> RemoveWhere<T>(this ICollection<T> iCollection, Func<T,bool> predicate) => iCollection.Except(iCollection.Where(e => predicate(e)));
        public static T WeightedRandom<T>(this ICollection<T> collection, Func<T, float> weightFunc)
        {
            float total = collection.Sum(weightFunc);

            float itemWeightIndex = Random.Range(0, 1f) * total;

            float currentWeight = 0;
            foreach (var item  in collection)
            {
                currentWeight += weightFunc(item);

                if (currentWeight > itemWeightIndex) return item;
            }
        
            throw new Exception("Weighted Random failed to return an item, check your weighFunc");
        }
        
        public static bool TryFindFirst<T>(this ICollection<T> source, Func<T, bool> condition, out T found)
        {
            found = source.FirstOrDefault(condition);
            return source.Count != 0 && condition(found);
        }
    
        public static IEnumerable<T> Shuffle<T>(this ICollection<T> source) => 
            source.OrderBy(t => t.GetHashCode() + Random.Range(0, source.Count * 2));
    }
}