using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Decorator
{
    class Tomato: Ingredient
    {
        public Tomato(FastFood ff)
            : base(ff)
        {
        }

        public override decimal Cost()
        {
            return 0.3m + FastFood.Cost();
        }
    }
}
