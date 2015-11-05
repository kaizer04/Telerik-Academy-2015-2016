namespace PrintStatistics
{
    using System;

    public class StatisticsPrinter
    {
        public void PrintStatistics(double[] array)
        {
            var maxElement = FindMaxElement(array);
            this.Print(maxElement.ToString());

            var minElement = FindMinElement(array);
            this.Print(minElement.ToString());

            var averageOfElementsValue = FindAverageOfArrayElements(array);
            this.Print(averageOfElementsValue.ToString());
        }

        private static double FindAverageOfArrayElements(double[] array)
        {
            double sumOfElements = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sumOfElements += array[i];
            }

            var averageOfElements = sumOfElements / array.Length;

            return averageOfElements;
        }

        private static double FindMinElement(double[] array)
        {
            var minElement = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < minElement)
                {
                    minElement = array[i];
                }
            }

            return minElement;
        }

        private static double FindMaxElement(double[] array)
        {
            var maxElement = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxElement)
                {
                    maxElement = array[i];
                }
            }

            return maxElement;
        }

        private void Print(string elementToPrint)
        {
            Console.WriteLine(elementToPrint);
        }
    }
}
