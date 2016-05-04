namespace MostCommon
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> firstNames = new Dictionary<string, int>();
            Dictionary<string, int> lastNames = new Dictionary<string, int>();
            Dictionary<string, int> years = new Dictionary<string, int>();
            Dictionary<string, int> eyes = new Dictionary<string, int>();
            Dictionary<string, int> hairs = new Dictionary<string, int>();
            Dictionary<string, int> heights = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] characteristics = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                AddElementToDictionary(characteristics[0], firstNames);
                AddElementToDictionary(characteristics[1], lastNames);
                AddElementToDictionary(characteristics[2], years);
                AddElementToDictionary(characteristics[3], eyes);
                AddElementToDictionary(characteristics[4], hairs);
                AddElementToDictionary(characteristics[5], heights);
            }

            Console.WriteLine(SearchElement(firstNames));
            Console.WriteLine(SearchElement(lastNames));
            Console.WriteLine(SearchElement(years));
            Console.WriteLine(SearchElement(eyes));
            Console.WriteLine(SearchElement(hairs));
            Console.WriteLine(SearchElement(heights));
        }

        private static void AddElementToDictionary(string key, Dictionary<string, int> dictionary)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, 1);
            }
            else
            {
                dictionary[key]++;
            }
        }

        private static string SearchElement(Dictionary<string, int> dictionary)
        {
            string result = string.Empty;
            int max = int.MinValue;
            foreach (var item in dictionary)
            {
                if (item.Value > max)
                {
                    result = item.Key;
                    max = item.Value;
                }
                else if (item.Value == max)
                {
                    if (result.CompareTo(item.Key) > 0)
                    {
                        result = item.Key;
                    }
                }
            }

            return result;
        }
    }
}
