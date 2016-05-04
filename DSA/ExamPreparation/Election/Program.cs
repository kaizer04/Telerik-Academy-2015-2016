namespace Election
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            var parties = new List<int>();
            for (int i = 0; i < n; i++)
            {
                parties.Add(int.Parse(Console.ReadLine()));
            }

            //parties = Enumerable.Repeat(1, 100).ToList();
            //k = 1;
            var answer = Solve(parties, k);
            Console.WriteLine(answer);
        }

        private static BigInteger Solve(List<int> parties, int k)
        {
            var sums = new BigInteger[parties.Sum() + 1];
            var maxSum = 0;
            sums[0] = 1;

            for (int i = 0; i < parties.Count; i++)
            {
                var num = parties[i];
                for (int j = maxSum; j >= 0; j--)
                {
                    // is sum possible
                    if (sums[j] > 0)
                    {
                        sums[j + num] += sums[j];
                        maxSum = Math.Max(j + num, maxSum);
                    }
                }
            }

            BigInteger combinations = 0;
            for (int i = k; i <= parties.Sum(); i++)
            {
                combinations += sums[i];
            }

            return combinations;
        }
    }
}
