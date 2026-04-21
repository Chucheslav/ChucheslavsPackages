using System;
using System.Collections.Generic;
using System.Linq;

namespace Tools
{
    public static class IDictionaryExtensions
    {
        public static void RemoveWhereKey<TKey, TValue>(this IDictionary<TKey, TValue> dict, 
            Func<TValue,bool> predicate)
        {
            List<TKey> keys = dict.Keys.Where(k => predicate(dict[k])).ToList();
            foreach (var key in keys)
            {
                dict.Remove(key);
            }
        }
    }
}