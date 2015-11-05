using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Decorator
{
    public class DecoratorMain
    {
        public static void Main(string[] args)
        {
            FastFood sandwich = new Sandwich();

            sandwich = new Tomato(sandwich);
            sandwich = new Ham(sandwich);
            sandwich = new Cheese(sandwich);


            Console.WriteLine(sandwich.Cost());

            Console.ReadKey();
        }
    }
}
