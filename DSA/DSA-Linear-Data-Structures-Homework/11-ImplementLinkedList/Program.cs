namespace _11_ImplementLinkedList
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
            var test = new JLinkedList<int>();

            test.AddItem(7);

            test.AddItem(18);

            test.AddItem(22);

            Console.WriteLine(test);

            test.RemoveItem(181);

            Console.WriteLine(test);
        }
    }
}
