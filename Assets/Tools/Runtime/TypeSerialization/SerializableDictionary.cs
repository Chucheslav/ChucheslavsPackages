// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;
//
// namespace Tools.TypeSerialization
// {
//     public class SerializableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
//     {
//         [Serializable]
//         protected class Entry
//         {
//             public readonly TKey key;
//             public TValue value;
//
//             protected Entry(){}
//
//             protected Entry(TKey key, TValue value)
//             {
//                 this.key = key;
//                 this.value = value;
//             }
//         }
//         
//         [SerializeField] protected List<Entry> dictionary = new List<Entry>();
//         
//         public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
//         {
//             dictionary.GetEnumerator();
//         }
//
//         IEnumerator IEnumerable.GetEnumerator()
//         {
//             return GetEnumerator();
//         }
//
//         public void Add(KeyValuePair<TKey, TValue> item)
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public void Clear()
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public bool Contains(KeyValuePair<TKey, TValue> item)
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public bool Remove(KeyValuePair<TKey, TValue> item)
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public int Count { get; }
//         public bool IsReadOnly { get; }
//         public void Add(TKey key, TValue value)
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public bool ContainsKey(TKey key)
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public bool Remove(TKey key)
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public bool TryGetValue(TKey key, out TValue value)
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public TValue this[TKey key]
//         {
//             get => throw new System.NotImplementedException();
//             set => throw new System.NotImplementedException();
//         }
//
//         public ICollection<TKey> Keys => dictionary.Select(x => x.key).ToArray();
//         public ICollection<TValue> Values => dictionary.Select(e => e.value).ToArray();
//     }
// }
