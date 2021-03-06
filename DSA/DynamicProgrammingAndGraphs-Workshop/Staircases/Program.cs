﻿namespace Staircases
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static long[,] count;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            count = new long[n + 1, n + 1];

            long result = 0;
            for (int i = 1; i < n; i++)
            {
                result += Stairs(n, i);
            }

            Console.WriteLine(result);
        }

        static long Stairs(int n, int k)
        {
            if (n < 3 && n == k)
            {
                return 1;
            }

            if (count[n, k] > 0)
            {
                return count[n, k];
            }

            for (int i = 0; i < k && i <= n - k; i++)
            {
                //if (n - k <= i)
                //{
                //    break;
                //}
                count[n, k] += Stairs(n - k, i);
            }

            return count[n, k];
        }
    }
}
