
using UdonSharp;
using UnityEngine;

namespace UArrayCollections
{
    public class UDict : UdonSharpBehaviour
    {
        public static void Initialize<TKey, TValue>(ref TKey[] keyArray, ref TValue[] valueArray)
        {
            UList.Initialize(ref keyArray);
            UList.Initialize(ref valueArray);
        }

        public static void Add<TKey, TValue>(ref TKey[] keyArray, ref TValue[] valueArray, TKey key, TValue value)
        {
            Debug.Assert(keyArray.Length == valueArray.Length, $"the number of elements in both arrays do not match.");
            if (UList.Contains(keyArray, key))
            {
                Debug.LogWarning($"key '{key}' is already in the keyArray");
                return;
            }
            UList.Add(ref keyArray, key);
            UList.Add(ref valueArray, value);
        }

        public static void Remove<TKey, TValue>(ref TKey[] keyArray, ref TValue[] valueArray, TKey key)
        {
            Debug.Assert(keyArray.Length == valueArray.Length, $"the number of elements in both arrays do not match.");
            var index = UList.IndexOf(keyArray, key);
            if (index < 0) { return; }
            UList.RemoveAt(ref keyArray, index);
            UList.RemoveAt(ref valueArray, index);
        }

        public static TValue GetValue<TKey, TValue>(TKey[] keyArray, TValue[] valueArray, TKey key)
        {
            if (keyArray.Length != valueArray.Length) { return default; }
            var index = UList.IndexOf(keyArray, key);
            if (index < 0) { return default; }
            return valueArray[index];
        }
    }
}
