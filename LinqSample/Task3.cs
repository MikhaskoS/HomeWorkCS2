using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSample
{
    class Task3
    {
        //delegate int my_delegate (KeyValuePair<string, int> pair);

        public static void Demo1()
        {
            //----------------------------------------------------------
            //  Условие задачи
            //----------------------------------------------------------
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) {
                return pair.Value;
            });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            Console.WriteLine("---------------------------");

            // OrderBy (свернули)
            d = dict.OrderBy(k => k. Value);
            d.Print();
            Console.WriteLine("---------------------------");


            // OrderBy (разернули)
            d = dict.OrderBy(SampleFunc);
            d.Print();
        }

        static int SampleFunc(KeyValuePair<string, int> pair)
        {
            return pair.Value;
        }
    }
}
