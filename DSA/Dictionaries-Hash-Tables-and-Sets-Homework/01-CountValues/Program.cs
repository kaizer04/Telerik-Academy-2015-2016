namespace _01_CountValues
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            IDictionary<double, int> countDict = new Dictionary<double, int>();
            //var numbers = new List<double>() { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            double[] numbers = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            foreach (var number in numbers)
            {
                if (!(countDict.ContainsKey(number)))
                {
                    countDict[number] = 0;
                }
                countDict[number]++;
            }

            foreach (var count in countDict)
            {
                Console.WriteLine("{0} -> {1} times", count.Key, count.Value);
            }
        }
    }
}