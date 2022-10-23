
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
            int nidx = 0;
            Array.Copy(array, 0, new_array, nidx, array.Length);
            nidx += array.Length;
            Array.Copy(values, 0, array, nidx, values.Length);
            array = new_array;
        }

        public static void Insert<T>(ref T[] array, int index, T value)
        {
            Debug.Assert(index >= 0 && index < array.Length, $"'index' is out of range.");
            T[] new_array = new T[array.Length + 1];
            int nidx = 0;
            Array.Copy(array, 0, new_array, nidx, index);
            nidx += index;
            new_array[nidx] = value;
            nidx++;
            Array.Copy(array, index, new_array, nidx, array.Length - index);
            array = new_array;
        }

        public static void InsertRange<T>(ref T[] array, int index, T[] values)
        {
            Debug.Assert(index >= 0 && index < array.Length, $"'index' is out of range.");
            T[] new_array = new T[array.Length + values.Length];
            int nidx = 0;
            Array.Copy(array, 0, new_array, nidx, index);
            nidx += index;
            Array.Copy(values, 0, array, nidx, values.Length);
            nidx += values.Length;
            Array.Copy(array, index, new_array, nidx, array.Length - index);
            array = new_array;
        }

        public static void RemoveAt<T>(ref T[] array, int index)
        {
            Debug.Assert(index >= 0 && index < array.Length, $"'index' is out of range.");
            T[] new_array = new T[array.Length - 1];
            int nidx = 0;
            Array.Copy(array, 0, new_array, nidx, index);
            nidx += index;
            Array.Copy(array, index + 1, new_array, nidx, array.Length - index - 1);
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
            while (true)
            {
                int index = IndexOf(array, value);
                if (index == -1) { return; }
            }
        }

        public static void RemoveRange<T>(ref T[] array, int index, int count)
        {
            Debug.Assert(index >= 0 && index < array.Length, $"'index' is out of range.");
            Debug.Assert(count >= 0, $"count is out of range.");
            if (index + count >= array.Length) { count = array.Length - index; }
            if (count == 0) { return; }
            T[] new_array = new T[array.Length - count];
            int nidx = 0;
            Array.Copy(array, 0, new_array, nidx, index);
            nidx += index;
            Array.Copy(array, index + count, new_array, nidx, array.Length - index - count);
            array = new_array;
        }

        public static void Resize<T>(ref T[] array, int length)
        {
            Debug.Assert(length >= 0, $"'length' is out of range.");
            T[] new_array = new T[length];
            int len = array.Length > length ? length : array.Length;
            Array.Copy(array, 0, new_array, 0, len);
            array = new_array;
        }

        public static void Reverse<T>(ref T[] array)
        {
            T[] new_array = new T[array.Length];
            int nidx = 0;
            for (int i = array.Length - 1; i > -1; i--)
            {
                new_array[nidx] = array[i];
                nidx++;
            }
            array = new_array;
        }

        public static int IndexOf<T>(T[] array, T value)
        {
            return IndexOf(array, value, 0);
        }

        public static int IndexOf<T>(T[] array, T value, int start)
        {
            for (int i = start; i < array.Length; i++)
            {
                if (array[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        public static int LastIndexOf<T>(T[] array, T value)
        {
            return LastIndexOf(array, value, array.Length - 1);
        }

        public static int LastIndexOf<T>(T[] array, T value, int start)
        {
            for (int i = start; i > -1; i--)
            {
                if (array[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool Contains<T>(T[] array, T value)
        {
            return IndexOf(array, value, 0) != -1;
        }

        public static T[] GetRange<T>(T[] array, int index, int count)
        {
            Debug.Assert(index >= 0 && index < array.Length, $"'index' is out of range.");
            Debug.Assert(count >= 0, $"count is out of range.");
            if (index + count >= array.Length) { count = array.Length - index; }
            T[] new_array = new T[count];
            Array.Copy(array, index, new_array, 0, count);
            return new_array;
        }
    }
}
