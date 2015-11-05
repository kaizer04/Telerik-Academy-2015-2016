namespace _10_ShortestSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ShortestSequence
    {
        public static void Main()
        {
            List<int> operations = new List<int>();

            int n = 5;
            int m = 16;

            int newTarget = m;
            int multyPlierCounter = 0;

            operations.Add(n);

            while (newTarget / 2 >= n)
            {
                newTarget /= 2;
                multyPlierCounter++;
            }

            while (n < newTarget)
            {
                if (n + 2 < newTarget)
                {
                    n += 2;
                    operations.Add(n);
                }
                else if (n < newTarget)
                {
                    n++;
                    operations.Add(n);
                }
            }

            for (int i = 0; i < multyPlierCounter; i++)
            {
                n *= 2;
                operations.Add(n);
            }

            Console.WriteLine(string.Join(" -> ", operations));
        }
    }
}
