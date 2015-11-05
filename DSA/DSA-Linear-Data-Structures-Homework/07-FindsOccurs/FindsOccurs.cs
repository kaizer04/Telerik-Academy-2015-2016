namespace _07_FindsOccurs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FindsOccurs
    {
        public static void Main()
        {
            var arrayIntegers = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var dictionary = new Dictionary<int, int>();
            //// var dict = integers.GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count());
            for (int i = 0; i < arrayIntegers.Count(); i++)
            {
                if (dictionary.ContainsKey(arrayIntegers[i]))
                {
                    dictionary[arrayIntegers[i]]++;
                }
                else
                {
                    dictionary.Add(arrayIntegers[i], 1);
                }
            }
            
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + " --> " + item.Value + " times");
            }
        }
    }
}