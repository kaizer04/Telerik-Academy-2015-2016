namespace SortListInIncreasingOrder
{
    using System;
    using System.Collections.Generic;

    public class SortListInIncreasingOrder
    {
        public static void Main()
        {
            var listInt = new List<int>();
            string input = Console.ReadLine();
            while (input != string.Empty)
            {
                int inputInt = int.Parse(input);
                listInt.Add(inputInt);
                input = Console.ReadLine();
            }

            listInt.Sort();
            Console.WriteLine(string.Join(",", listInt));
        }
    }
}
