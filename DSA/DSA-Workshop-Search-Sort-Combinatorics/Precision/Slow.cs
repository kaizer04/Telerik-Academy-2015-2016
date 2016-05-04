//namespace Precision
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Text;
//    using System.Threading.Tasks;

//    public class Program
//    {
//        static int Divide(string fraction, int a, int b)
//        {
//            a *= 10;
//            int i = 0;
//            for (i = 0; i < fraction.Length; i++)
//            {
//                int digit = a / b;
//                if (digit != fraction[i] - '0')
//                {
//                    break;
//                }
//                a = a % b * 10;
//            }

//            return i;
//        }

//        public static void Main()
//        {
//            int maxDenominator = int.Parse(Console.ReadLine());
//            var fraction = Console.ReadLine().Split('.')[1];
//            //Console.WriteLine(Divide("14", 22, 7));
//            //Divide(1, 3);

//            int bestNom = 0;
//            int bestDen = 1;
//            int precision = 0;
//            for (int den = 1; den <= maxDenominator; den++)
//            {
//                for (int nom = 0; nom < den; nom++)
//                {
//                    int currentPrecision = Divide(fraction, nom, den);
//                    if (currentPrecision > precision)
//                    {
//                        bestNom = nom;
//                        bestDen = den;
//                        precision = currentPrecision;
//                    }
//                }
//            }

//            Console.WriteLine("{0}/{1}", bestNom, bestDen);
//            Console.WriteLine(precision + 1);
//        }
//    }
//}
