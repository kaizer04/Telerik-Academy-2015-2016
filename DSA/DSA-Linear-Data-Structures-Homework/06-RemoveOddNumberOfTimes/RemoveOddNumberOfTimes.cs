namespace _06_RemoveOddNumberOfTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RemoveOddNumberOfTimes
    {
        public static void Main()
        {
            var inputIntList = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < inputIntList.Count; i++)
            {
                if (dictionary.ContainsKey(inputIntList[i]))
                {
                    dictionary[inputIntList[i]]++;
                }
                else
                {
                    dictionary.Add(inputIntList[i], 1); 
                }
            }

            foreach (var item in dictionary)
            {
                if (item.Value % 2 != 0)
                {
                    inputIntList.RemoveAll(x => x == item.Key);
                }
            }

            Console.WriteLine(string.Join(", ", inputIntList));
        }
    }
}