namespace FindOccurrencesInArrayByDoubleValues
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            double[] input = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            var dictionary = new SortedDictionary<double, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (dictionary.ContainsKey(input[i]))
                {
                    dictionary[input[i]]++;
                }
                else
                {
                    dictionary.Add(input[i], 1);
                }
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + " -> " + item.Value + " times");
            }

            Console.ReadKey(true);
        }
    }
}