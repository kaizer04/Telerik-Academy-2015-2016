namespace _08_MajorantOfArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MajorantOfArray
    {
        public static void Main()
        {
            var arrayIntegers = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            var dictionary = new Dictionary<int, int>();
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

            //// var majElement = array.FirstOrDefault(x => dict[x] >= array.Length / 2 + 1);
            var minOccursTimes = (arrayIntegers.Count() / 2) + 1;
            bool isExists = false;
            int majorant = 0;
            foreach (var item in dictionary)
            {
                if (item.Value >= minOccursTimes)
                {
                    isExists = true;
                    majorant = item.Key;
                }
            }

            if (isExists)
            {
                Console.WriteLine("{0} --> {1}", string.Join(", ", arrayIntegers), majorant); 
            }
            else
            {
                Console.WriteLine("Not exists");
            }
        }
    }
}
