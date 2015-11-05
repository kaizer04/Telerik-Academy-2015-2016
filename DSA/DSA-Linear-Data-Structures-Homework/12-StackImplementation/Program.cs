namespace _12_StackImplementation
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
            var testing = new JStack<int>();

            testing.Push(1);
            testing.Push(2);
            Console.WriteLine(testing.Peek());
            Console.WriteLine(testing.Pop());
            Console.WriteLine(testing.Count);
            Console.WriteLine(testing.Peek());
            Console.WriteLine(testing.Count);
            testing.Push(1);
            testing.Push(2);
            testing.Push(1);
            testing.Push(2);
            testing.Push(1);
            testing.Push(2);
            Console.WriteLine(testing.Count);
        }
    }
}
