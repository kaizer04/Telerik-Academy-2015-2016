namespace TRES4Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ConvertDecimalToTres4Numbers
    {
        public static string ConvertDigitToChar(int digit)
        {
            string tres4Number = string.Empty;
            switch (digit)
            {
                case 0:
                    tres4Number = "LON+";
                    break;
                case 1:
                    tres4Number = "VK-";
                    break;
                case 2:
                    tres4Number = "*ACAD";
                    break;
                case 3:
                    tres4Number = "^MIM";
                    break;
                case 4:
                    tres4Number = "ERIK|";
                    break;
                case 5:
                    tres4Number = "SEY&";
                    break;
                case 6:
                    tres4Number = "EMY>>";
                    break;
                case 7:
                    tres4Number = "/TEL";
                    break;
                case 8:
                    tres4Number = "<<DON";
                    break;
            }

            return tres4Number;
        }

        public static void Main()
        {
            ulong inputNumber = ulong.Parse(Console.ReadLine());
            List<int> listOfDigits = new List<int>();
            if (inputNumber == 0)
            {
                listOfDigits.Add((int)inputNumber);
            }

            while (inputNumber > 0)
            {
                int digitToAdd = (int)inputNumber % 9;
                listOfDigits.Add(digitToAdd);
                inputNumber = inputNumber / 9;
            }

            listOfDigits.Reverse();

            PrintTRES4Numbers(listOfDigits);
        }

        private static void PrintTRES4Numbers(List<int> listOfDigits)
        {
            for (int i = 0; i < listOfDigits.Count; i++)
            {
                Console.Write(ConvertDigitToChar(listOfDigits[i]));
            }

            Console.WriteLine();
        }
    }
}
