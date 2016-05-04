namespace Palindromize
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
            //Console.WriteLine(IsPalindrome("abbba"));
            //Console.WriteLine(IsPalindrome("a"));
            //Console.WriteLine(IsPalindrome("acca"));
            //Console.WriteLine(IsPalindrome("xyzzzz"));
            // Input
            var str = Console.ReadLine();

            var answer = Palindromize(str);

            // Output
            Console.WriteLine(answer);
        }

        private static bool IsPalindrome(string str)
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static string Palindromize(string str)
        {
            //if (IsPalindrome(str))
            //{
            //    return str;
            //}

            for (int numberOfChars = 0; numberOfChars < str.Length; numberOfChars++)
            {
                var firstIChars = str.Substring(0, numberOfChars).ToCharArray();
                Array.Reverse(firstIChars);
                var candidate = str + new string(firstIChars);
                if (IsPalindrome(candidate))
                {
                    return candidate;
                }
            }

            return string.Empty;
        }
    }
}
