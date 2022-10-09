
using UdonSharp;
using UnityEngine;

namespace UArrayCollections
{
    public class UStack : UdonSharpBehaviour
    {
        public static void Initialize<T>(ref T[] array)
        {
            UList.Initialize(ref array);
        }

        public static void Push<T>(ref T[] array, T value)
        {
            UList.Insert(ref array, 0, value);
        }

        public static T Pop<T>(ref T[] array)
        {
            if (array.Length == 0) { return default; }
            T value = array[0];
            UList.RemoveAt(ref array, 0);
            return value;
        }

        public static T Peek<T>(T[] array)
        {
            if (array.Length == 0) { return default; }
            return array[0];
        }
    }
}
