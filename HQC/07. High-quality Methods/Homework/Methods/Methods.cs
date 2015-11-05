namespace Methods
{
    using System; 

    public class Methods
    {
        public static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            bool isPositiveSides = sideA >= 0 || sideB >= 0 || sideC >= 0;
            bool isTriangle = (sideA + sideC > sideB) && (sideB + sideC > sideA) && (sideA + sideB > sideC);

            if (!isPositiveSides || !isTriangle)
            {
                throw new ArgumentException("The value of sides are not for a triangle!");
            }

            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
            
            return area;
        }

        public static string ConvertDigitToItsName(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: return "Invalid digit!";
            }
        }

        public static int FindMaxElementInArrayOfIntegers(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("You don`t have entered elements!");
            }

            int maxElement = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        public static void PrintAsNumber(object number, string format)
        {
            string printFormat = string.Empty;
            switch (format)
            {
                case "f": printFormat = "{0:f2}";
                    break;
                case "%": printFormat = "{0:p0}";
                    break;
                case "r": printFormat = "{0,8}";
                    break;
                default:
                    throw new ArgumentException("Invalid format!");
            }
            
            Console.WriteLine(printFormat, number);
        }

        public static double CalcDistanceBetweenPoints(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

            return distance;
        }

        public static bool IsHorizontalLine(double x1, double y1, double x2, double y2)
        {
            bool isHorizontal = y1 == y2;

            return isHorizontal;
        }

        public static bool IsVerticalLine(double x1, double y1, double x2, double y2)
        {
            bool isVertical = x1 == x2;

            return isVertical;
        }

        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(ConvertDigitToItsName(15));

            Console.WriteLine(FindMaxElementInArrayOfIntegers(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            Console.WriteLine(CalcDistanceBetweenPoints(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + IsHorizontalLine(3, -1, 3, 2.5));
            Console.WriteLine("Vertical? " + IsVerticalLine(3, -1, 3, 2.5));

            Student peter = new Student("Peter", "Ivanov", "17.03.1992", "From Sofia");
            Student stella = new Student("Stella", "Markova", "03.11.1993", "From Vidin, gamer, high results");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
