using ExtensionMethods_NS;
using System;
using System.Collections.Generic;

namespace LINQ_Extension_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> temp = new Dictionary<int, int>();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                temp.Add(i, r.Next(1, 20));
            }
            foreach (var item in temp)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //var tester = temp.ExtensionSelect(i => i.Key);

            //var tester = temp.ExtensionSelect(i => i.Value);

            //var tester = temp.ExtensionWhere(i => (i.Key > 5));

            //var tester = temp.ExtensionGroupBy(i => i.Value );

            //var tester = temp.ExtensionToList();

            //var tester = temp.ExtensionToDictionary(i=>i.Key+1);

            //var tester = temp.ExtensionOrderByAsc(i => i.Value);

            var tester = temp.ExtensionOrderByDesc(i => i.Value);

            foreach (var item in tester)
            {
                Console.WriteLine(item);
            }
        }
    }
}
