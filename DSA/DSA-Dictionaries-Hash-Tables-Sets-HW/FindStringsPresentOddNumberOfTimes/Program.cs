namespace FindStringsPresentOddNumberOfTimes
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = new List<string>() { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            var dictionary = new Dictionary<string, int>();
            var output = new List<string>();

            for (int i = 0; i < input.Count; i++)
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
                if (item.Value % 2 != 0)
                {
                    output.Add(item.Key);
                }
            }

            Console.WriteLine("{" + string.Join(", ", input) + "} -> {" + string.Join(", ", output) + "}");
            Console.ReadKey(true);
        }
    }
}