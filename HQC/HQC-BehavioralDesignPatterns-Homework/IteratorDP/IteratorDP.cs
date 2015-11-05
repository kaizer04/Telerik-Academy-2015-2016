using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IteratorDP
{
    public class IteratorDP
    {
        public static void Main()
        {
            ConcreteAggregate arrayList = new ConcreteAggregate();

            arrayList[0] = "Item A";
            arrayList[1] = "Item B";
            arrayList[2] = "Item C";
            arrayList[3] = "Item D";

            // Create Iterator and provide aggregate
            ConcreteIterator iterator = new ConcreteIterator(arrayList);

            Console.WriteLine("Iterating over collection:");

            object item = iterator.First();

            while (item != null)
            {
                Console.WriteLine(item);
                item = iterator.Next();
            }

            // Wait for user
            Console.ReadKey();
        }
    }   
}