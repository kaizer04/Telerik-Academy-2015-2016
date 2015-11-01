namespace SequenceInList
{
    using System;
    using System.Collections.Generic;

    public class SumAndAverage
    {
        public static void Main()
        {
            var listInt = new List<int>();
            var sum = 0;
            string input = Console.ReadLine();
            while (input != string.Empty) 
            {
                int inputInt = int.Parse(input);
                listInt.Add(inputInt);
                sum += inputInt;
                input = Console.ReadLine();
            }

            Console.WriteLine("The sum is {0}", sum);
            Console.WriteLine("The average is {0}", sum / listInt.Count);
        }
    }
}
