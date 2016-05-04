namespace RepeatingPattern
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
            string str = Console.ReadLine();
            for (int i = 1; i <= str.Length; i++)
            {
                if (str.Length % i > 0)
                {
                    continue;
                }

                string pattern = str.Substring(0, i);
                bool isOk = true;
                for (int j = i; j < str.Length; j += i)
                {
                    if (pattern != str.Substring(j, i))
                    {
                        isOk = false;
                        break;
                    }
                }

                if (isOk)
                {
                    Console.WriteLine(pattern);
                    break;
                }
            }
        }
    }
}
