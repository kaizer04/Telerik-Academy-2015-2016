namespace Towns
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
            var n = int.Parse(Console.ReadLine());
            var nums = new List<int>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var lineParts = line.Split(' ');
                int num = int.Parse(lineParts[0]);
                nums.Add(num);
            }

            var answer = Solve(nums);
            Console.WriteLine(answer);
        }

        private static int Solve(List<int> nums)
        {
            // 1. max increasing subsequences left-right
            var lefToRight = new int[nums.Count];
            for (int i = 0; i < nums.Count; i++)
            {
                var maxLength = 0;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        maxLength = Math.Max(maxLength, lefToRight[j]);
                    }
                }

                lefToRight[i] = maxLength + 1;
            }

            // 2. max increasing subsequences right-left
            var rightToLeft = new int[nums.Count];
            for (int i = nums.Count - 1; i >= 0; i--)
            {
                var maxLength = 0;
                for (int j = nums.Count - 1; j > i; j--)
                {
                    if (nums[j] < nums[i])
                    {
                        maxLength = Math.Max(maxLength, rightToLeft[j]);
                    }
                }

                rightToLeft[i] = maxLength + 1;
            }
            
            // 3. combine and find max answer
            var maxPath = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                var path = lefToRight[i] + rightToLeft[i] - 1;
                maxPath = Math.Max(maxPath, path);
            }

            return maxPath;
        }
    }
}
