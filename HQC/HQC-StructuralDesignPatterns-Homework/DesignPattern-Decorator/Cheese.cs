using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Decorator
{
    class Cheese: Ingredient
    {
        public Cheese(FastFood ff)
            : base(ff)
        {
        }

        public override decimal Cost()
        {
            return 0.75m + FastFood.Cost();
        }
    }
}
