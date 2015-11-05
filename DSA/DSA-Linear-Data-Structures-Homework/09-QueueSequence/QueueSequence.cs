namespace _09_QueueSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class QueueSequence
    {
        public static void Main()
        {
            var sequence = new Queue<int>();
            var result = new List<int>();

            int n = int.Parse(Console.ReadLine());
            sequence.Enqueue(n);
            int count = 1;
            while (count <= 50)
            {
                int current = sequence.Dequeue();
                result.Add(current);
                count++;

                sequence.Enqueue(current + 1);
                sequence.Enqueue((2 * current) + 1);
                sequence.Enqueue(current + 2);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
