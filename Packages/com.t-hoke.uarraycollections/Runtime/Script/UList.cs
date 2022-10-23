
using System;
using UdonSharp;
using UnityEngine;

namespace UArrayCollections
{
    public class UList : UdonSharpBehaviour
    {
        public static void Initialize<T>(ref T[] array)
        {
            array = new T[0];
        }

        public static void Add<T>(ref T[] array, T value)
        {
            T[] new_array = new T[array.Length + 1];
            Array.Copy(array, new_array, array.Length);
            new_array[array.Length] = value;
            array = new_array;
        }

        public static void AddRange<T>(ref T[] array, T[] values)
        {
            T[] new_array = new T[array.Length + values.Length];
            Array.Copy(array, 0, new_array, 0, array.Length);
            Array.Copy(values, 0, new_array, array.Length, values.Length);
            array = new_array;
        }

        public static void Insert<T>(ref T[] array, int index, T value)
        {
            Debug.Assert((index < 0 || index > array.Length), $"'index' is out of range.");
            T[] new_array = new T[array.Length + 1];
            Array.Copy(array, 0, new_array, 0, index);
            new_array[index] = value;
            Array.Copy(array, index, new_array, index + 1, array.Length - index);
            array = new_array;
        }

        public static void InsertRange<T>(ref T[] array, int index, T[] values)
        {
            Debug.Assert((index < 0 || index > array.Length), $"'index' is out of range.");
            if (values.Length == 0)
            {
                return;
            }

            T[] new_array = new T[array.Length + values.Length];
            Array.Copy(array, 0, new_array, 0, index);
            Array.Copy(values, 0, array, index, values.Length);
            Array.Copy(array, index, new_array, index + values.Length, array.Length - index);
            array = new_array;
        }

        public static void RemoveAt<T>(ref T[] array, int index)
        {
            Debug.Assert((index < 0 || index >= array.Length), $"'index' is out of range.");
            T[] new_array = new T[array.Length - 1];
            Array.Copy(array, 0, new_array, 0, index);
            Array.Copy(array, index + 1, new_array, index, array.Length - index - 1);
            array = new_array;
        }

        public static void Remove<T>(ref T[] array, T value)
        {
            int index = IndexOf(array, value);
            if (index == -1) { return; }
            RemoveAt(ref array, index);
        }

        public static void RemoveAll<T>(ref T[] array, T value)
        {
            int length = array.Length;
            int currentIndex = 0;
            for (int i = 0; i < length; i++)
            {
                array[currentIndex] = array[i];
                if (!array[i].Equals(value))
                {
                    currentIndex++;
                }
            }
            Resize(ref array, currentIndex);
        }

        public static void RemoveRange<T>(ref T[] array, int index, int count)
        {
            Debug.Assert((index < 0 || index >= array.Length), $"'index' is out of range.");
            Debug.Assert((count < 0), $"count is out of range.");
            
            count = Mathf.Min(count, array.Length - index);
            if (count == 0) { return; }

            T[] new_array = new T[array.Length - count];
            Array.Copy(array, 0, new_array, 0, index);
            Array.Copy(array, index + count, new_array, index, array.Length - index - count);
            array = new_array;
        }

        public static void Resize<T>(ref T[] array, int length)
        {
            Debug.Assert((length < 0), $"'length' is out of range.");
            if (array.Length == length)
            {
                return;
            }
            T[] new_array = new T[length];
            Array.Copy(array, 0, new_array, 0, Mathf.Min(array.Length, length));
            array = new_array;
        }

        public static void Reverse<T>(ref T[] array)
        {
            Array.Reverse(array);
        }

        public static int IndexOf<T>(T[] array, T value)
        {
            return Array.IndexOf(array, value);
        }

        public static int IndexOf<T>(T[] array, T value, int start)
        {
            return Array.IndexOf(array, value, start);
        }

        public static int LastIndexOf<T>(T[] array, T value)
        {
            return Array.LastIndexOf(array, value);
        }

        public static int LastIndexOf<T>(T[] array, T value, int start)
        {
            return Array.LastIndexOf(array, value, start);
        }

        public static bool Contains<T>(T[] array, T value)
        {
            return Array.IndexOf(array, value) != -1;
        }

        public static T[] GetRange<T>(T[] array, int index, int count)
        {
            Debug.Assert((index < 0 || index >= array.Length), $"'index' is out of range.");
            Debug.Assert((count < 0), $"count is out of range.");

            count = Mathf.Min(count, array.Length - index);

            T[] new_array = new T[count];
            Array.Copy(array, index, new_array, 0, count);
            return new_array;
        }
    }
}
