namespace Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            //Console.WriteLine(GetHashCode(new[] {8, 7, 6, 5, 4, 3, 2, 1}));
            var n = int.Parse(Console.ReadLine());
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var k = int.Parse(Console.ReadLine());

            var answer = Solve(nums, k);
            Console.WriteLine(answer);
        }

        private static int Solve(int[] nums, int k)
        {
            // Key -> permutation number (HashCode)
            // Value -> min path to Key
            var visited = new Dictionary<int, int>();

            var queue = new Queue<int[]>();
            queue.Enqueue(nums);
            visited.Add(GetHashCode(nums), 0);

            while (queue.Count > 0)
            {
                var currPerm = queue.Dequeue();
                var currPath = visited[GetHashCode(currPerm)];
                if (IsSorted(currPerm))
                {
                    return currPath;
                }

                for (int i = 0; i <= nums.Length - k; i++)
                {
                    var desc = currPerm.Clone() as int[];
                    Array.Reverse(desc, i, k);
                    if (!visited.ContainsKey(GetHashCode(desc)))
                    {
                        visited.Add(GetHashCode(desc), currPath + 1);
                        queue.Enqueue(desc);   
                    }
                }
            }

            return -1;
        }

        static int GetHashCode(int[] values)
        {
            int hash = 0;

            //for (int i = 0; i < values.Length; i++)
            //{
            //    hash *= 8;
            //    hash += values[i];
            //}

            foreach (var val in values)
            {
                hash *= 8;
                hash += val;
            }

            return hash;

            // Test var visited = new Dictionary<string, int>();
            //var sb = new StringBuilder();
            //foreach (var val in values)
            //{
            //    sb.Append(val);
            //}

            //return sb.ToString();

            //return string.Join(string.Empty, values);
        }

        static bool IsSorted(int[] perm)
        {
            for (int i = 1; i < perm.Length; i++)
            {
                if (perm[i] < perm[i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
