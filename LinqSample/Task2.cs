using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqSample
{
    class Task2
    {
        public static void Demo1()
        {
            // Генерируем список случайных чисел
            Random rnd = new Random();
            List<int> _list = rnd.GetRandomIntValues(50, -10, 10).ToList();

            // обычный способ
            Dictionary<int, int> _dict = Counter<int>(_list);
            _dict.Print();

            Console.WriteLine(new string(':', 50));
            //-----------------------------------------------------------------
            // Linq способ 1
            // удаляем повтояющиеся элементы с сортировкой
            var key = _list.Distinct().OrderBy(s=>s);  
            foreach (int t in key)
            {
                Console.WriteLine( $"{t}: {_list.Count(s => s==t)}" );
            }
            Console.WriteLine(new string(':', 50));
            //----------------------------------------------------------------
            // Linq способ 2
            var query = _list.GroupBy(s => s);
            foreach (IGrouping<int, int> grouping in query)
            {
                Console.WriteLine($"Value: {grouping.Key} Cont: {grouping.Count()}" );
            }
            Console.WriteLine(new string(':', 50));
            //----------------------------------------------------------------
            // Linq способ 3
            string GetGroupKey(int n)
            {
                return n.ToString("0000");
            }
            var counts3 = _list.GroupBy(GetGroupKey)
                .Select(group => new { value = group.Key, count = group.Count() })
                .OrderBy(v => v.value)
                .ToArray();

            counts3.Print();
            Console.WriteLine(new string(':', 50));
            //----------------------------------------------------------------
            // Linq способ 4
            var count4 = _list.GroupBy(n => n)
                .ToDictionary(group => group.Key, group => group.Count());

            count4.Print();
        }


        public static Dictionary<T, int> Counter<T>(List<T> list)
        {
            Dictionary<T, int> _dict = new Dictionary<T, int>();
            foreach (T t in list)
            {
                if (_dict.ContainsKey(t)) _dict[t]++;
                else _dict.Add(t, 1);
            }
            return _dict;
        }
    }
}
