namespace ShortestPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        private static char[] map;

        private static SortedSet<string> results = new SortedSet<string>();

        public static void Find(int index)
        {
            if (index == map.Length)
            {
                results.Add(new string(map));
            }
            else if (map[index] != '*')
            {
                Find(index + 1);
            }
            else
            {
                map[index] = 'R';
                Find(index + 1);
                map[index] = 'L';
                Find(index + 1);
                map[index] = 'S';
                Find(index + 1);
                map[index] = '*';
            }
        }

        public static void Main()
        {
            map = Console.ReadLine().ToCharArray();

            Find(0);

            Console.WriteLine(results.Count);
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
    }
}
