namespace HashTables
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            //			var p1 = new KeyValuePair<int, int>(1, 3);
            //			var p2 = new KeyValuePair<int, int>(1, 2);
            //			Console.WriteLine(p1.Equals(p2));

            //			int[] values = { 1, 2, 4, 5 };
            //			var cachedValues = values;
            //			values = new int[]{ 5, 6, 7, 8 };
            //			Console.WriteLine(string.Join(", ", cachedValues));

            var table = new HashDictionary<string, int>();

            table.Add("Pesho", 5);
            table.Add("Gosho", 5);
            //table.Add("Pesho", 5);
            //table.Add("Pesho", 5);
            Console.WriteLine(table.ContainsKey("Pesho"));
            Console.WriteLine(table.ContainsKey("Pesho2"));
            //foreach (var pair in table)
            //{
            //    Console.WriteLine(pair.Key + " -> " + pair.Value);
            //}
        }
    }
}