namespace PrintBoolVar
{
    using System;

    public class Printer
    {
        private const int MaxCount = 6;

        public Printer()
        {
        }

        public void Print(bool value)
        {
            Console.WriteLine(value);
        }
    }
}
