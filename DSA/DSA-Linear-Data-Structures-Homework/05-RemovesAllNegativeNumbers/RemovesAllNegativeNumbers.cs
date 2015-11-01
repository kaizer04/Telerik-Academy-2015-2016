namespace _05_RemovesAllNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RemovesAllNegativeNumbers
    {
        public static void Main()
        {
            var sequence = new List<int> { -3, -4, -4, -2, -3, -3, -3, -4, 3, -2 };
            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] < 0)
                {
                    sequence.Remove(sequence[i]);
                    i = i - 1;
                }
            }

            //// sequence.RemoveAll(x => x < 0);

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
