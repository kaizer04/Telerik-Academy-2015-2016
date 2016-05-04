using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passwords
{
    class Program
    {
        private static char[] input;

        private static string[] password;

        private static SortedSet<string> results = new SortedSet<string>();

        public static void Find(int index)
        {
            //if (index == password.Length)
            //{
            //    results.Add(new string(password));
            //}
            //else if (password[index] != '*')
            //{
            //    Find(index + 1);
            //}
            //else
            //{
            //    password[index] = 'R';
            //    Find(index + 1);
            //    password[index] = 'L';
            //    Find(index + 1);
            //    password[index] = 'S';
            //    Find(index + 1);
            //    password[index] = '*';
            //}
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            input = Console.ReadLine().ToCharArray();
            int k = int.Parse(Console.ReadLine());

            password = new string[n];

            for (int i = 0; i < password.Length; i++)
            {
                password[i] = string.Format("{0}", i);
                
            }

            results.Add(password.ToString());

            Console.WriteLine(string.Join(", ", results));
            //Find(0);
        }
    }
}
