using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Decorator
{
    class Ham : Ingredient
    {
        public Ham(FastFood ff)
            : base(ff)
        {
        }

        public override decimal Cost()
        {
            return 1m + FastFood.Cost();
        }
    }
}
