using System;
using System.Collections.Generic;
using System.Text;

namespace LinqSample
{
    static class Utility
    {
        public static IEnumerable<int> GetRandomIntValues(this Random rnd, int Count, int Min, int Max)
        {
            for (var i = 0; i < Count; i++)
                yield return rnd.Next(Min, Max);
        }

        public static T NextValue<T>(this Random rnd, params T[] Variants)
        {
            return Variants[rnd.Next(0, Variants.Length)];
        }

        public static void Print<T>(this List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"[{i}]:\t {list[i]}");
            }
        }
        public static void Print<K, V>(this Dictionary<K, V> dict)
        {
            foreach(K t in dict.Keys)
                Console.WriteLine($"[{t}]:\t {dict[t]}");
        }

        public static void Print<T>(this IEnumerable<T> enumerable)
        {
            foreach (T t in enumerable)
                Console.WriteLine($"{t} "); 
        }
    }
}
