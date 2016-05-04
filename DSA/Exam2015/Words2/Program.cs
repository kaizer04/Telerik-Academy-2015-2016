using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            int sum = 0;
            for (int i = 1; i <= text.Length; i++)
            {
                if (text.Length % i > 0)
                {
                    continue;
                }

                //string pattern = text.Substring(0, i);
                bool isOk = true;
                for (int j = i; j < text.Length; j += i)
                {
                    for (int k = 0; k < pattern.Length; k++)
                    {
                        if (pattern != text.Substring(j, i))
                        {
                            isOk = false;
                            break;
                        }
                    }
                    
                }

                if (isOk)
                {
                    //Console.WriteLine(pattern);
                    sum++;
                    break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
