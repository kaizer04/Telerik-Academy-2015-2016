namespace ReverseIntsWithStack
{
    using System;
    using System.Collections.Generic;

    public class ReverseIntsWithStack
    {
        public static void Main()
        {
            var stackInt = new Stack<int>();
            string input = Console.ReadLine();
            while (input != string.Empty)
            {
                int inputInt = int.Parse(input);
                stackInt.Push(inputInt);
                input = Console.ReadLine();
            }

            Console.WriteLine("Reversed stack:");
            int stackIntCount = stackInt.Count;
            for (int i = 0; i < stackIntCount; i++)
            {
                Console.Write(stackInt.Pop() + ", ");
            }

            Console.WriteLine();
        }
    }
}
