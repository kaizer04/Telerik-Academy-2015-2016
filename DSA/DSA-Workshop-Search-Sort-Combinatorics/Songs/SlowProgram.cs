//namespace Songs
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Text;
//    using System.Threading.Tasks;

//    public class Program
//    {
//        public static void Main()
//        {
//            int n = int.Parse(Console.ReadLine());

//            var array1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//            var array2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//            var rename = new int[n + 1];

//            for (int i = 0; i < n; i++)
//            {
//                rename[array1[i]] = i;
//            }

//            for (int i = 0; i < n; i++)
//            {
//                array2[i] = rename[array2[i]];
//            }

//            int inversions = 0;

//            //// slow again 27/100
//            //// var index1 = new int[n + 1];
//            //// var index2 = new int[n + 1];
//            //// for (int i = 1; i <= n; i++)
//            //// {
//            ////     index1[i] = Array.IndexOf(array1, i);
//            ////     index2[i] = Array.IndexOf(array2, i);
//            //// }

//            for (int i = 0; i < n; i++)
//            {
//                for (int j = i + 1; j < n; j++)
//                {
//                    if (array2[i] > array2[j])
//                    {
//                        inversions++;
//                    }
//                }

//            }

//            //// slow 11/100
//            //// int inversions = 0;
//            //// for (int i = 1; i <= n; i++)
//            //// {
//            ////     int index1i = Array.IndexOf(array1, i);
//            ////     int index2i = Array.IndexOf(array2, i);
//            ////     for (int j = i + 1; j <= n; j++)
//            ////     {
//            ////         int index1j = Array.IndexOf(array1, j);
//            ////         int index2j = Array.IndexOf(array2, j);
//            ////         if ((index1i < index1j) ^ (index2i < index2j))
//            ////         {
//            ////             inversions++;
//            ////         }
//            ////     }

//            //// }

//            Console.WriteLine(inversions);
//        }
//    }
//}
