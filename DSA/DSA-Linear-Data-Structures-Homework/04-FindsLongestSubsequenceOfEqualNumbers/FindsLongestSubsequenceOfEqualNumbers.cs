namespace FindsLongestSubsequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FindsLongestSubsequenceOfEqualNumbers
    {
        public static void Main()
        {
            var input = new List<int> { 3, 4, 4, 2, 3, 3, 3, 4, 3, 2 };
            var result = GetLongestSubsequenceOfEqualNumbers(input);
            Console.WriteLine(string.Join(", ", result));
        }

        private static List<int> GetLongestSubsequenceOfEqualNumbers(List<int> listInt)
        {
            var longestListEqualNumbers = new List<int>();
            int currentCount = 1;
            int countNumbers = 0;
            int number = listInt[0];
            for (int i = 0; i < listInt.Count - 1; i++)
            {
                if (listInt[i] == listInt[i + 1])
                {
                    currentCount++;
                }
                else
                {
                    currentCount = 1;
                }

                if (currentCount > countNumbers)
                {
                    countNumbers = currentCount;
                    number = listInt[i];
                }
            }

            for (int i = 0; i < countNumbers; i++)
            {
                longestListEqualNumbers.Add(number);
            }
           
            return longestListEqualNumbers;
        }
    }
}
